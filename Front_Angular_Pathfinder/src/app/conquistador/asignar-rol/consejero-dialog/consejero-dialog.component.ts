import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from "@angular/material/dialog";
import { Component, Inject } from "@angular/core";
import { Validators, UntypedFormGroup, UntypedFormBuilder } from "@angular/forms";
import { UnidadService, UsuarioService } from "src/app/core/repositories";
import { UsuarioRol } from "src/app/core/models";
import { UnsubscribeOnDestroyAdapter } from "src/app/shared/UnsubscribeOnDestroyAdapter";
import { UsuariosDialogComponent } from "../usuarios-dialog/usuarios-dialog.component";
import { UnidadDialogComponent } from "../../registro/formulario/unidad-dialog/unidad-dialog.component";
@Component({
    selector: "app-consejero-dialog",
    templateUrl: "./consejero-dialog.component.html",
    styleUrls: [],
})
export class ConsejeroDialogComponent extends UnsubscribeOnDestroyAdapter {
    consejeroForm: UntypedFormGroup;
    consejero: UsuarioRol;
    isSaving = false;
    edit: boolean;

    constructor(
        public dialogRef: MatDialogRef<ConsejeroDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any,
        public usuarioService: UsuarioService,
        public dialog: MatDialog,
        private fb: UntypedFormBuilder,
        private unidadService: UnidadService
    ) {
        super();
        this.consejero = new UsuarioRol();
        this.consejero.UsuaId = data.UsuaId;
        this.consejero.UsuaUsuario = data.UsuaUsuario;
        this.consejero.PersNombres = data.PersNombres;
        this.consejero.UnidId = data.UnidId;
        this.consejero.UnidNombre = data.UnidNombre;
        this.edit = data.edit;
        this.consejeroForm = this.createConsejeroForm();
    }

    createConsejeroForm(): UntypedFormGroup {
        return this.fb.group({
            UsuaId: [this.consejero.UsuaId, [Validators.required]],
            UsuaUsuario: [this.consejero.UsuaUsuario, [Validators.required]],
            PersNombres: [this.consejero.PersNombres, [Validators.required]],
            UnidId: [this.consejero.UnidId, [Validators.required]],
            UnidNombre: [this.consejero.UnidNombre, [Validators.required]]
        });
    }

    submit() {
        if (this.isSaving) {
            return;
        }
        debugger;
        this.isSaving = true;
        this.consejero.UsuaId = this.consejeroForm.get('UsuaId').value;
        this.consejero.UsuaUsuario = this.consejeroForm.get('UsuaUsuario').value;
        this.consejero.PersNombres = this.consejeroForm.get('PersNombres').value;
        this.consejero.UnidId = this.consejeroForm.get('UnidId').value;
        this.consejero.UnidNombre = this.consejeroForm.get('UnidNombre').value;
        this.usuarioService.setUsuario(this.consejero);
    }

    async SearchUsuarios() {
        if (this.edit) {
            return;
        }
        if (this.consejeroForm.get('UsuaId').value > 0) {
            this.consejeroForm.get('UsuaId').setValue(null);
            this.consejeroForm.get('UsuaUsuario').setValue(null);
            this.consejeroForm.get('PersNombres').setValue(null);
        } else {
            const dialogRef = this.dialog.open(UsuariosDialogComponent, {});
            this.subs.sink = dialogRef.afterClosed().subscribe((result) => {
                if (result === 1) {
                    let usuario = this.usuarioService.getDialogData();
                    this.consejeroForm.get('UsuaId').setValue(usuario.UsuaId);
                    this.consejeroForm.get('UsuaUsuario').setValue(usuario.UsuaUsuario);
                    this.consejeroForm.get('PersNombres').setValue(usuario.PersNombres);
                }
            })
        }
    }

    SearchUnidades() {
        if (this.consejeroForm.get('UnidId').value) {
            this.consejeroForm.get('UnidId').setValue(null);
            this.consejeroForm.get('UnidNombre').setValue(null);
        } else {
            const dialogRef = this.dialog.open(UnidadDialogComponent, {});
            this.subs.sink = dialogRef.afterClosed().subscribe((result) => {
                if (result === 1) {
                    if (this.unidadService.getDialogData()) {
                        let unidad = this.unidadService.getDialogData();
                        this.consejeroForm.get('UnidId').setValue(unidad.UnidId);
                        this.consejeroForm.get('UnidNombre').setValue(unidad.UnidNombre);
                    }
                }
            })
        }
    }

    onNoClick(): void {
        this.dialogRef.close();
    }
}
