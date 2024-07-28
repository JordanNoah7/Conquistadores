import { Component, OnInit } from "@angular/core";
import { MatDialog } from "@angular/material/dialog";
import { UntypedFormBuilder, UntypedFormGroup, Validators } from "@angular/forms";
import Swal from "sweetalert2";
import { AuthService } from "src/app/core/service/auth.service";
@Component({
    selector: "app-dialogform",
    templateUrl: "./change-password.component.html",
    styleUrls: ["./change-password.component.sass"],
})
export class ChangePasswordComponent implements OnInit {
    hide = false;
    hideN = false;
    isSaving = false;
    public changePasswordForm: UntypedFormGroup;

    constructor(private fb: UntypedFormBuilder,
        public dialog: MatDialog,
        private authService: AuthService) { }

    public ngOnInit(): void {
        this.changePasswordForm = this.fb.group({
            newpassword: [null, [Validators.required, Validators.minLength(8), Validators.maxLength(12)],],
            renewpassword: [null, [Validators.required, Validators.minLength(8), Validators.maxLength(12)],],
        });
    }

    closeDialog(): void {
        this.dialog.closeAll();
    }

    async onSubmitClick() {
        if (this.isSaving) {
            return;
        }
        this.isSaving = true;
        if (this.changePasswordForm.invalid) {
            Swal.fire({
                title: 'Error',
                text: `Debe llenar los campos con al menos 8 caracteres.`,
                icon: 'error',
            });
            this.isSaving = false;
        }
        else {
            if (this.changePasswordForm.controls.newpassword.value != this.changePasswordForm.controls.renewpassword.value) {
                Swal.fire({
                    title: 'Información',
                    text: `Las contraseñas no son iguales, vuelva a intentar.`,
                    icon: 'warning',
                });
                this.isSaving = false;
            }
            else {
                const hasUpperCase = /[A-Z]/.test(this.changePasswordForm.controls.newpassword.value);
                const hasLowerCase = /[a-z]/.test(this.changePasswordForm.controls.newpassword.value);
                const hasNumber = /[0-9]/.test(this.changePasswordForm.controls.newpassword.value);
                const hasSpecialChar = /[!@#$%^&*(),.?":{}|<>]/.test(this.changePasswordForm.controls.newpassword.value);
                const hasValidLength = this.changePasswordForm.controls.newpassword.value.length >= 8;
                const isValid = hasUpperCase && hasLowerCase && hasNumber && hasSpecialChar && hasValidLength;
                if (!isValid) {
                    Swal.fire({
                        title: 'Requisitos de la contraseña:',
                        text: `Debe tener al menos 8 caracteres.
                                Debe contener al menos una letra minúscula.
                                Debe contener al menos una letra mayúscula.
                                Debe contener al menos un número.
                                Debe incluir al menos un carácter especial (por ejemplo: !@#$%^&*).`,
                        icon: 'warning',
                    });
                    this.isSaving = false;
                } else {
                    const user = localStorage.getItem("user");
                    localStorage.clear();
                    await this.authService.ChangePassword(user, this.changePasswordForm.controls.newpassword.value).subscribe({
                        next: (value: any) => {
                            if (value) {
                                Swal.fire({
                                    icon: "success",
                                    title: "La contraseña ha sido cambiada exitosamente.",
                                    showConfirmButton: true,
                                });
                                this.SignIn(user, this.changePasswordForm.controls.newpassword.value);
                            }
                        },
                        error: (error: any) => {
                            Swal.fire({
                                title: 'Error',
                                text: `No se pudo cambiar la contraseña.`,
                                icon: 'error',
                            });
                        },
                        complete: () => {
                            this.isSaving = false;
                        }
                    })
                }
            }
        }
    }

    private async SignIn(user: string, password: string) {
        await this.authService.Login(user, password).subscribe({
            error: (error: any) => {
                Swal.fire({
                    title: 'Error!',
                    text: error,
                    icon: 'error',
                    confirmButtonText: 'Cool'
                });
            },
        })
    }
}