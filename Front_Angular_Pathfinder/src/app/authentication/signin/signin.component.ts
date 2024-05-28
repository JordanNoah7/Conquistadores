import {Component, OnInit} from "@angular/core";
import {Router, ActivatedRoute} from "@angular/router";
import {UntypedFormBuilder, UntypedFormGroup, Validators} from "@angular/forms";
import {AuthService} from "src/app/core/service/auth.service";
import {Role} from "src/app/core/models/role";
import {UnsubscribeOnDestroyAdapter} from "src/app/shared/UnsubscribeOnDestroyAdapter";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";

@Component({
   selector: "app-signin",
   templateUrl: "./signin.component.html",
   styleUrls: ["./signin.component.scss"],
})
export class SigninComponent
   extends UnsubscribeOnDestroyAdapter
   implements OnInit {
   authForm: UntypedFormGroup;
   submitted = false;
   loading = false;
   error = "";
   hide = true;
   ip = "";
   hostname = "";

   constructor(
      private formBuilder: UntypedFormBuilder,
      private route: ActivatedRoute,
      private router: Router,
      private authService: AuthService,
      private http: HttpClient
   ) {
      super();
   }

   ngOnInit() {
      this.authForm = this.formBuilder.group({
         username: ["", Validators.required],
         password: ["", Validators.required],
      });
   }

   get f() {
      return this.authForm.controls;
   }

   onSubmit() {
      this.submitted = true;
      this.loading = true;
      this.error = "";
      if (this.authForm.invalid) {
         this.error = "Datos incorrectos";
         return;
      } else {
         this.getPublicIp().subscribe(data => {
            this.ip = data.ip;
         });
         this.hostname = this.getHostName();
         this.subs.sink = this.authService
            .login(this.f.username.value, this.f.password.value)
            .subscribe(
               (res) => {
                  if (res) {
                     setTimeout(() => {
                        const role = this.authService.currentUserValue.role;
                        if (role === Role.All || role === Role.Admin) {
                           this.router.navigate(["/admin/dashboard/main"]);
                        } else if (role === Role.Doctor) {
                           this.router.navigate(["/doctor/dashboard"]);
                        } else if (role === Role.Patient) {
                           this.router.navigate(["/patient/dashboard"]);
                        } else {
                           this.router.navigate(["/authentication/signin"]);
                        }
                        this.loading = false;
                     }, 1000);
                  } else {
                     this.error = "Invalid Login";
                  }
               },
               (error) => {
                  this.error = error;
                  this.submitted = false;
                  this.loading = false;
               }
            );
      }
   }

   getPublicIp(): Observable<any> {
      return this.http.get('https://api.ipify.org?format=json');
   }

   getHostName(): string {
      return window.location.hostname;
   }
}
