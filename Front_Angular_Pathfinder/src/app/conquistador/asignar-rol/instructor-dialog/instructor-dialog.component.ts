import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from "@angular/material/dialog";
import { Component, Inject } from "@angular/core";
import { Validators, UntypedFormGroup, UntypedFormBuilder } from "@angular/forms";
import { ClaseService, UsuarioService } from "src/app/core/repositories";
import { UsuarioRol } from "src/app/core/models";
import { UnsubscribeOnDestroyAdapter } from "src/app/shared/UnsubscribeOnDestroyAdapter";
import { UsuariosDialogComponent } from "../usuarios-dialog/usuarios-dialog.component";
import { ClaseDialogComponent } from "../../registro/formulario/clase-dialog/clase-dialog.component";
@Component({
    selector: "app-instructor-dialog",
    templateUrl: "./instructor-dialog.component.html",
    styleUrls: [],
})
export class InstructorDialogComponent extends UnsubscribeOnDestroyAdapter {
    instructorForm: UntypedFormGroup;
    instructor: UsuarioRol;
    isSaving = false;
    ClasNombre: string = '';
    edit: boolean;

    constructor(
        public dialogRef: MatDialogRef<InstructorDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any,
        public usuarioService: UsuarioService,
        public dialog: MatDialog,
        private fb: UntypedFormBuilder,
        private claseService: ClaseService,
    ) {
        super();
        this.instructor = new UsuarioRol();
        this.instructor.UsuaId = data.UsuaId;
        this.instructor.UsuaUsuario = data.UsuaUsuario;
        this.instructor.PersNombres = data.PersNombres;
        this.instructor.ClasId = data.ClasId;
        this.instructor.ClasNombre = data.ClasNombre;
        this.edit = data.edit;
        this.instructorForm = this.createInstructorForm();
    }

    createInstructorForm(): UntypedFormGroup {
        return this.fb.group({
            UsuaId: [this.instructor.UsuaId, [Validators.required]],
            UsuaUsuario: [this.instructor.UsuaUsuario, [Validators.required]],
            PersNombres: [this.instructor.PersNombres, [Validators.required]],
            ClasId: [this.instructor.ClasId, [Validators.required]],
            ClasNombre: [this.instructor.ClasNombre, [Validators.required]]
        });
    }

    submit() {
        if (this.isSaving) {
            return;
        }
        debugger;
        this.isSaving = true;
        this.instructor.UsuaId = this.instructorForm.get('UsuaId').value;
        this.instructor.UsuaUsuario = this.instructorForm.get('UsuaUsuario').value;
        this.instructor.PersNombres = this.instructorForm.get('PersNombres').value;
        this.instructor.ClasId = this.instructorForm.get('ClasId').value;
        this.instructor.ClasNombre = this.instructorForm.get('ClasNombre').value;
        this.usuarioService.setUsuario(this.instructor);
    }

    async SearchUsuarios() {
        if (this.edit) {
            return;
        }
        if (this.instructorForm.get('UsuaId').value > 0) {
            this.instructorForm.get('UsuaId').setValue(null);
            this.instructorForm.get('UsuaUsuario').setValue(null);
            this.instructorForm.get('PersNombres').setValue(null);
        } else {
            const dialogRef = this.dialog.open(UsuariosDialogComponent, {});
            this.subs.sink = dialogRef.afterClosed().subscribe((result) => {
                if (result === 1) {
                    let usuario = this.usuarioService.getDialogData();
                    this.instructorForm.get('UsuaId').setValue(usuario.UsuaId);
                    this.instructorForm.get('UsuaUsuario').setValue(usuario.UsuaUsuario);
                    this.instructorForm.get('PersNombres').setValue(usuario.PersNombres);
                }
            })
        }
    }

    SearchClases() {
        if (this.instructorForm.get('ClasId').value) {
            this.instructorForm.get('ClasId').setValue(null);
            this.instructorForm.get('ClasNombre').setValue(null);
        } else {
            const dialogRef = this.dialog.open(ClaseDialogComponent, {});
            this.subs.sink = dialogRef.afterClosed().subscribe((result) => {
                if (result === 1) {
                    if (this.claseService.getDialogData()) {
                        let clase = this.claseService.getDialogData();
                        this.instructorForm.get('ClasId').setValue(clase.ClasId);
                        this.instructorForm.get('ClasNombre').setValue(clase.ClasNombre);
                    }
                }
            })
        }
    }

    onNoClick(): void {
        this.dialogRef.close();
    }
}
