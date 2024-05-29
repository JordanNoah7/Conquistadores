import {Component, OnInit} from '@angular/core';
import {FormGroup, Validators, FormControl} from '@angular/forms';
import {
   UserService,
   RouterService,
   NotificationService,
} from 'src/app/core/services';
import {ActivatedRoute} from '@angular/router';

import {ReCaptchaV3Service} from 'ng-recaptcha';
import {HttpClient} from '@angular/common/http';
import {IcuPlaceholder} from '@angular/compiler/src/i18n/i18n_ast';

@Component({
   selector: 'ns-login',
   templateUrl: './login.component.html',
})
export class LoginComponent implements OnInit {
   public form: FormGroup = new FormGroup({
      username: new FormControl('', [
         Validators.required,
         Validators.maxLength(50),
      ]),
      password: new FormControl('', [
         Validators.required,
         Validators.maxLength(120),
      ]),
   });

   public loading = false;
   public showPassword: boolean = false;
   public tokenCaptcha: any;
   private ip: string = '';

   constructor(
      public routerService: RouterService,
      private userService: UserService,
      private route: ActivatedRoute,
      private notificationService: NotificationService,
      private recaptchaV3Service: ReCaptchaV3Service,
      private http: HttpClient
   ) {
   }

   ngOnInit() {
      localStorage.removeItem('visited');
   }

   public login() {
      this.loading = true;
      this.recaptchaV3Service.execute('login').subscribe(
         (token: string) => {
            this.tokenCaptcha = token;
            this.validateForm();
         },
         (error) => {
            this.notificationService.showSmallMessage(
               'Error de validación Captcha',
               false
            );
            this.loading = false;
         }
      );
   }

   private async validateForm() {
      if (this.form.valid) {
         await this.GetIp();

         setTimeout(async () => {
            await this.userService.signIn(
               (<any>this.username).value,
               (<any>this.password).value,
               <any>this.tokenCaptcha,
               this.ip
            );
            this.loading = false;
         }, 1000);
      } else {
         this.notificationService.showSmallMessage('Datos incorrectos', false);
         this.loading = false;
      }
   }

   private async GetIp() {
      await this.http.get('http://api.ipify.org/?format=json').subscribe((res: any) => {
         this.ip = res.ip;
      });
   }

   get username() {
      return this.form.get('username');
   }

   get password() {
      return this.form.get('password');
   }
}
