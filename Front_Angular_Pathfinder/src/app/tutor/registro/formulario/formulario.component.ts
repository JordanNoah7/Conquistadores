import { Component, OnInit } from "@angular/core";
import { UntypedFormBuilder, UntypedFormGroup, Validators } from "@angular/forms";
import { MatDialog } from "@angular/material/dialog";
import { ActivatedRoute, Params, Router } from "@angular/router";
import { UnsubscribeOnDestroyAdapter } from "src/app/shared/UnsubscribeOnDestroyAdapter";
import { ConquistadoresDialogComponent } from "./conquistadores-dialog/conquistadores-dialog.component";
import { ConquistadorService, TutorService } from "src/app/core/repositories";
import Swal from "sweetalert2";
import { Tutor } from "src/app/core/models";
import { Usuario } from "src/app/core/models/Usuario";
@Component({
    selector: "app-formulario",
    templateUrl: "./formulario.component.html",
    styleUrls: [],
})
export class FormularioComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
    tutorForm: UntypedFormGroup;
    hide1 = false;
    hide2 = false;
    title = '';
    id = 0;
    isSaving = false;

    constructor(
        private fb: UntypedFormBuilder,
        private route: ActivatedRoute,
        public dialog: MatDialog,
        private conquistadorService: ConquistadorService,
        private tutorService: TutorService,
        private router: Router,
    ) {
        super();
    }

    ngOnInit(): void {
        this.route.params.subscribe((params: Params) => (
            (this.id = Number(params['T']))
        ));
        this.title = this.id > 0 ? 'Actualizar' : 'Nuevo';
        this.tutorForm = this.createTutorForm();
        if (this.id > 0) {
            this.GetTutor();
        }
    }

    onSubmit() {
        if (this.isSaving) {
            return;
        }
        this.isSaving = true;
        const c = this.tutorForm.get('UsuaContrasenia').value;
        const rc = this.tutorForm.get('UsuaReContrasenia').value;
        if (c != rc) {
            Swal.fire({
                title: 'Error!',
                text: "Las contraseñas no son iguales, verifique e intente nuevamente.",
                icon: 'error',
                confirmButtonText: 'Ok'
            });
            this.isSaving = false;
            return;
        }
        let tutor: Tutor = new Tutor();
        tutor.Usuario = new Usuario();
        tutor.PersId = this.tutorForm.get('PersId').value;
        tutor.PersDni = this.tutorForm.get('PersDni').value;
        tutor.PersNombres = this.tutorForm.get('PersNombres').value;
        tutor.PersApellidoPaterno = this.tutorForm.get('PersApellidoPaterno').value;
        tutor.PersApellidoMaterno = this.tutorForm.get('PersApellidoMaterno').value;
        tutor.PersFechaNacimiento = this.tutorForm.get('PersFechaNacimiento').value;
        tutor.PersCorreoPersonal = this.tutorForm.get('PersCorreoPersonal').value;
        tutor.PersCorreoCorporativo = this.tutorForm.get('PersCorreoCorporativo').value;
        tutor.PersCelular = this.tutorForm.get('PersCelular').value.toString();
        tutor.PersTelefono = this.tutorForm.get('PersTelefono').value.toString();
        tutor.PersSexo = this.tutorForm.get('PersSexo').value;
        tutor.PersDireccionCasa = this.tutorForm.get('PersDireccionCasa').value;
        tutor.PersNacionalidad = this.tutorForm.get('PersNacionalidad').value;
        tutor.PersRegion = this.tutorForm.get('PersRegion').value;
        tutor.PersCiudad = this.tutorForm.get('PersCiudad').value;
        tutor.TutoCentroTrabajo = this.tutorForm.get('TutoCentroTrabajo').value;
        tutor.TutoDireccionTrabajo = this.tutorForm.get('TutoDireccionTrabajo').value;
        tutor.Usuario.UsuaId = this.tutorForm.get('UsuaId').value;
        tutor.Usuario.UsuaUsuario = this.tutorForm.get('UsuaUsuario').value;
        tutor.Usuario.UsuaContrasenia = this.tutorForm.get('UsuaContrasenia').value;
        this.tutorService.saveTutor(tutor).subscribe({
            next: (value: any) => {
                Swal.fire({
                    icon: "success",
                    title: value,
                    showConfirmButton: true,
                });
            },
            error: (error: any) => {
                Swal.fire({
                    title: 'Error!',
                    text: error,
                    icon: 'error',
                    confirmButtonText: 'Ok'
                });
                this.isSaving = false;
            },
            complete: () => {
                this.isSaving = false;
                this.GoToRegistro();
            }
        })
    }

    createTutorForm(): UntypedFormGroup {
        return this.fb.group({
            PersId: [0],
            PersDni: ['', [Validators.required]],
            PersNombres: ['', [Validators.required]],
            PersApellidoPaterno: ['', [Validators.required]],
            PersApellidoMaterno: ['', [Validators.required]],
            PersFechaNacimiento: ['', [Validators.required]],
            PersCorreoPersonal: ['', [Validators.required, Validators.email]],
            PersCorreoCorporativo: ['', [Validators.email]],
            PersCelular: ['', [Validators.required, Validators.minLength(9), Validators.maxLength(9)]],
            PersTelefono: ['', [Validators.minLength(9), Validators.maxLength(9)]],
            PersSexo: ['', [Validators.required]],
            PersDireccionCasa: ['', [Validators.required]],
            PersNacionalidad: ['', [Validators.required]],
            PersRegion: ['', [Validators.required]],
            PersCiudad: ['', [Validators.required]],
            TutoCentroTrabajo: ['', [Validators.required]],
            TutoDireccionTrabajo: ['', [Validators.required]],
            UsuaId: [0],
            UsuaUsuario: ['', [Validators.required]],
            UsuaContrasenia: [''],
            UsuaReContrasenia: [''],
        });
    }

    async GetTutor() {
        await this.tutorService.getTutor(this.id).subscribe({
            next: (value: any) => {
                console.log(value);
                this.tutorForm.patchValue(value);
                this.tutorForm.get('UsuaId').setValue(value.Usuario.UsuaId);
                this.tutorForm.get('UsuaUsuario').setValue(value.Usuario.UsuaUsuario);
            },
            error: (error: any) => {
                Swal.fire({
                    title: 'Error!',
                    text: error,
                    icon: 'error',
                    confirmButtonText: 'Ok'
                });
            }
        })
    }

    async SearchConquistadores() {
        const dialogRef = this.dialog.open(ConquistadoresDialogComponent, {});
        this.subs.sink = dialogRef.afterClosed().subscribe((result) => {
            if (result === 1) {
                this.conquistadorService.getConquistadorById(this.conquistadorService.getDialogData()).subscribe({
                    next: (value: any) => {
                        this.tutorForm.patchValue(value);
                    },
                    error: (error: any) => {
                        Swal.fire({
                            title: 'Error!',
                            text: error,
                            icon: 'error',
                            confirmButtonText: 'Ok'
                        });
                    }
                });
            }
        })
    }

    GoToRegistro() {
        this.router.navigate(['/tutor/registro']);
    }
}
