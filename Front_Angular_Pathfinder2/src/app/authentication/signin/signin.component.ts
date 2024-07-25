import Swal from 'sweetalert2'
import { AuthService } from "src/app/core/service/auth.service";
import { CarouselConfig } from 'ngx-bootstrap/carousel';
import { Component, OnInit } from "@angular/core";
import { ReCaptchaV3Service } from "ng-recaptcha";
import { UnsubscribeOnDestroyAdapter } from "src/app/shared/UnsubscribeOnDestroyAdapter";
import { UntypedFormBuilder, Validators } from "@angular/forms";
import { MatDialog } from '@angular/material/dialog';
import { ChangePasswordComponent } from './change-password/change-password.component';

@Component({
    selector: "app-signin",
    templateUrl: "./signin.component.html",
    styleUrls: ["./signin.component.scss"],
    providers: [
        { provide: CarouselConfig, useValue: { interval: 3000, noPause: false, showIndicators: true, isAnimated: true } }
    ],
})
export class SigninComponent
    extends UnsubscribeOnDestroyAdapter
    implements OnInit {
    loading = false;
    error = "";
    hide = false;
    tokenCaptcha: any;
    slides = [
        { image: './assets/images/login/img-auth-2.jpg', text: 'Diviertete y aventurate con las salidas y caminatas.', title: 'Salidas y caminatas' },
        { image: './assets/images/login/img-auth-3.jpg', text: 'Despeja tu mente y crea una mejor conexión con la naturaleza.', title: 'Campamentos' },
        { image: './assets/images/login/img-auth-1.jpg', text: 'El club de conquistadores es una familia con la que contarás siempre.', title: 'Familia' }
    ];
    authForm = this.formBuilder.group({
        username: ["", Validators.required],
        password: ["", Validators.required],
    });

    constructor(
        private formBuilder: UntypedFormBuilder,
        private authService: AuthService,
        private recaptchaV3Service: ReCaptchaV3Service,
        private dialogModel: MatDialog,
    ) {
        super();
    }

    async ngOnInit() {
        localStorage.removeItem('visited');
    }

    get f() {
        return this.authForm.controls;
    }

    onSubmit() {
        if(this.loading){
            return;
        }
        this.loading = true;
        this.recaptchaV3Service.execute('login').subscribe({
            next: (token: string) => {
                this.tokenCaptcha = token;
                this.validateForm();
            },
            error: (error) => {
                Swal.fire({
                    title: 'Error!',
                    text: 'Error de validación Captcha',
                    icon: 'error',
                    confirmButtonText: 'Cool'
                })
                this.loading = false;
            }
        });
    }

    private async validateForm() {
        if (this.authForm.invalid) {
            Swal.fire({
                title: 'Error!',
                text: 'Datos incorrectos',
                icon: 'error',
                confirmButtonText: 'Cool'
            });
            this.loading = false;
        } else {
            await this.authService.Login(this.f.username.value, this.f.password.value, this.tokenCaptcha).subscribe({
                next: (value: any) => {
                    if (value.Usuario.UsuaCambiarContrasenia) {
                        const dialogRef = this.dialogModel.open(ChangePasswordComponent, {
                            width: "640px",
                            disableClose: true,
                        });
                    }
                },
                error: (error: any) => {
                    Swal.fire({
                        title: 'Error!',
                        text: error,
                        icon: 'error',
                        confirmButtonText: 'Cool'
                    });
                    this.loading = false;
                },
                complete: () => {
                    this.loading = false;
                }
            })
        }
    }
}
