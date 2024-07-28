import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { Request } from 'src/app/core/models/Request';
import { EncryptService } from 'src/app/core/service/encrypt.service';
import Swal from 'sweetalert2';
import { AuthService } from 'src/app/core/service/auth.service';
@Component({
    selector: 'app-forgot-password',
    templateUrl: './forgot-password.component.html',
    styleUrls: ['./forgot-password.component.scss'],
})
export class ForgotPasswordComponent implements OnInit {
    authForm: UntypedFormGroup;
    submitted = false;

    constructor(
        private formBuilder: UntypedFormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private encrypt: EncryptService,
        private authService: AuthService,
    ) { }

    ngOnInit() {
        this.authForm = this.formBuilder.group({
            username: ['', [Validators.required, Validators.minLength(5)],],
        });
    }

    get f() {
        return this.authForm.controls;
    }

    onSubmit() {
        if (this.submitted) {
            return;
        }
        if (this.authForm.invalid) {
            return;
        } else {
            this.submitted = true;
            Swal.fire({
                title: "Restablecer Contraseña",
                text: "¿Está seguro que desea generar una nueva contraseña?",
                icon: "warning",
                showCancelButton: true,
                confirmButtonColor: "#3085d6",
                cancelButtonColor: "#d33",
                confirmButtonText: "Si",
                cancelButtonText: "No"
            }).then(async (result) => {
                if (result.isConfirmed) {
                    const payload: Request = {
                        UsuaUsuario: this.encrypt.encryptAuth(this.f.username.value)
                    }
                    await this.authService.SendMail(payload).subscribe({
                        next: (value: any) => {
                            if (value.Mensaje) {
                                Swal.fire({
                                    icon: "success",
                                    title: value.Mensaje,
                                    showConfirmButton: true,
                                });
                            }
                        },
                        error: (value: any) => {
                            Swal.fire({
                                icon: "success",
                                title: value,
                                showConfirmButton: true,
                            });
                            this.router.navigate(["/authentication/signin"]);
                        },
                        complete: () => {
                            this.router.navigate(["/authentication/signin"]);
                        }
                    })
                }
                this.submitted = false;
            });
        }
    }
}
