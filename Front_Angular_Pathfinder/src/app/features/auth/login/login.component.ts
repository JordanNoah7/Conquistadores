import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, Validators, FormControl, AbstractControl } from '@angular/forms';
import {
    UserService,
    RouterService,
    NotificationService,
} from 'src/app/core/services';
import { ActivatedRoute } from '@angular/router';

import { ReCaptchaV3Service } from 'ng-recaptcha';
import { HttpClient } from '@angular/common/http';
import { IcuPlaceholder } from '@angular/compiler/src/i18n/i18n_ast';
import { ModalDirective } from "ngx-bootstrap/modal";

@Component({
    selector: 'ns-login',
    templateUrl: './login.component.html',
})
export class LoginComponent implements OnInit {
    @ViewChild('ModalChangePassword') public ModalChangePassword: | ModalDirective | undefined;
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

    public ChangePasswordForm: FormGroup = new FormGroup({
        newPassword: new FormControl('', [
            Validators.required,
            Validators.minLength(8),
        ]),
        reNewPassword: new FormControl('', [
            Validators.required,
            Validators.minLength(8),
        ]),
    });

    public loading: boolean = false;
    public isChanging: boolean = false;
    public showPassword: boolean = false;
    public showNewPassword: boolean = false;
    public showReNewPassword: boolean = false;
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
            setTimeout(async () => {
                let response = await this.userService.signIn(
                    (<any>this.username).value,
                    (<any>this.password).value,
                );
                if (response) {
                    this.ModalChangePassword?.show();
                }
                this.loading = false;
            }, 1000);
        } else {
            this.notificationService.showSmallMessage('Datos incorrectos', false);
            this.loading = false;
        }
    }

    public async ChangePassword() {
        if (this.isChanging) {
            return;
        }
        this.isChanging = true;
        if (this.ChangePasswordForm.valid) {
            if (this.newPassword?.value != this.reNewPassword?.value) {
                this.isChanging = false;
                return;
            } else {
                const hasUpperCase = /[A-Z]/.test(this.newPassword?.value);
                const hasLowerCase = /[a-z]/.test(this.newPassword?.value);
                const hasNumber = /[0-9]/.test(this.newPassword?.value);
                const hasSpecialChar = /[!@#$%^&*(),.?":{}|<>]/.test(this.newPassword?.value);
                const hasValidLength = this.newPassword?.value.length >= 8;
                const isValid = hasUpperCase && hasLowerCase && hasNumber && hasSpecialChar && hasValidLength;
                if (!isValid) {
                    this.notificationService.showSmallMessage('La contraseña debe tener al menos 8 caracteres y contener al menos una mayúscula, una minúscula, un número y un carácter especial.', false);
                } else {
                    let response = await this.userService.ChangePassword(this.username?.value, this.newPassword?.value);
                    if (response) {
                        this.notificationService.showSmallMessage('La contraseña ha sido cambiada exitosamente.', true);
                        await this.userService.signIn(this.username?.value, this.newPassword?.value);
                    } else {
                        this.notificationService.showSmallMessage('No se pudo cambiar la contraseña.', false);
                    }
                }
                this.isChanging = false;
            }
        } else {
            this.notificationService.showSmallMessage('Debe llenar ambos campos con al menos 8 caracteres.', false);
            this.isChanging = false;
        }
    }

    get username() {
        return this.form.get('username');
    }

    get password() {
        return this.form.get('password');
    }

    get newPassword() {
        return this.ChangePasswordForm.get('newPassword');
    }

    get reNewPassword() {
        return this.ChangePasswordForm.get('reNewPassword');
    }
}
