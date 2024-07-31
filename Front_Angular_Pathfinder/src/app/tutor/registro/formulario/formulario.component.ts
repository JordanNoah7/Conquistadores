import { Component, OnInit } from "@angular/core";
import { UntypedFormBuilder, UntypedFormGroup, Validators } from "@angular/forms";
import { MatDialog } from "@angular/material/dialog";
import { ActivatedRoute, Params } from "@angular/router";
import { UnsubscribeOnDestroyAdapter } from "src/app/shared/UnsubscribeOnDestroyAdapter";
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
    ) {
        super();
    }

    ngOnInit(): void {
        this.route.params.subscribe((params: Params) => (
            (this.id = Number(params['C']))
        ));
        this.title = this.id > 0 ? 'Actualizar' : 'Nuevo';
        this.tutorForm = this.createTutorForm();
    }

    onSubmit() {
        if (this.isSaving) {
            return;
        }
        this.isSaving = true;
        const c = this.tutorForm.get('UsuaContrasenia').value;
        const rc = this.tutorForm.get('UsuaReContrasenia').value;
        if (c != rc) {
            this.isSaving = false;
            return;
        }
    }

    createTutorForm(): UntypedFormGroup {
        return this.fb.group({
            PersId: [''],
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
            UsuaUsuario: ['', [Validators.required]],
            UsuaContrasenia: ['', [Validators.required]],
            UsuaReContrasenia: ['', [Validators.required]],
        });
    }
}
