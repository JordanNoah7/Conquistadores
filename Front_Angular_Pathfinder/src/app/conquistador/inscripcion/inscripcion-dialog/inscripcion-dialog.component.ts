import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from "@angular/material/dialog";
import { Component, Inject } from "@angular/core";
import { Validators, UntypedFormGroup, UntypedFormBuilder } from "@angular/forms";
import { ConquistadorService, InscripcionService } from "src/app/core/repositories";
import { Inscripcion } from "src/app/core/models";
import { ConquistadoresDialogComponent } from "src/app/tutor/registro/formulario/conquistadores-dialog/conquistadores-dialog.component";
import { UnsubscribeOnDestroyAdapter } from "src/app/shared/UnsubscribeOnDestroyAdapter";
import Swal from "sweetalert2";
@Component({
    selector: "app-form-dialog",
    templateUrl: "./inscripcion-dialog.component.html",
    styleUrls: [],
})
export class InscripcionDialogComponent extends UnsubscribeOnDestroyAdapter {
    inscripcionForm: UntypedFormGroup;
    inscripcion: Inscripcion;
    isSaving = false;
    costo: number = 0;
    nombres: string = '';
    edit: boolean;

    constructor(
        public dialogRef: MatDialogRef<InscripcionDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any,
        public inscripcionService: InscripcionService,
        private conquistadorService: ConquistadorService,
        public dialog: MatDialog,
        private fb: UntypedFormBuilder
    ) {
        super();
        this.inscripcion = new Inscripcion();
        this.inscripcion.ConqId = data.ConqId;
        this.inscripcion.InscMonto = data.InscMonto;
        this.costo = data.costo - this.inscripcion.InscMonto;
        this.nombres = data.nombres;
        this.edit = data.edit;
        this.inscripcionForm = this.createInscripcionForm();
    }

    createInscripcionForm(): UntypedFormGroup {
        return this.fb.group({
            ConqId: [this.inscripcion.ConqId, [Validators.required]],
            ConqNombres: [this.nombres, [Validators.required]],
            InscMonto: [0, [Validators.required]]
        });
    }

    submit() {
        if (this.costo - this.inscripcionForm.get('InscMonto').value < 0) {
            Swal.fire({
                title: 'Alerta',
                text: "No puede ingresar una cantidad mayor al coste de la inscripción.",
                icon: 'warning',
                confirmButtonText: 'Ok'
            });
            return;
        }
        if (this.isSaving) {
            return;
        }
        debugger;
        this.isSaving = true;
        this.inscripcion.ConqId = this.inscripcionForm.get('ConqId').value;
        this.inscripcion.InscMonto = this.inscripcionForm.get('InscMonto').value;
        this.inscripcion.InscCompleto = this.costo - this.inscripcionForm.get('InscMonto').value === 0;
        this.inscripcionService.add(this.inscripcion);
        this.onNoClick();
    }

    async SearchConquistadores() {
        if (this.edit) {
            return;
        }
        if (this.inscripcionForm.get('ConqId').value > 0) {
            this.inscripcionForm.get('ConqId').setValue(null);
            this.inscripcionForm.get('ConqNombres').setValue(null);
        } else {
            const dialogRef = this.dialog.open(ConquistadoresDialogComponent, {});
            this.subs.sink = dialogRef.afterClosed().subscribe((result) => {
                if (result === 1) {
                    this.conquistadorService.getConquistadorById(this.conquistadorService.getDialogData()).subscribe({
                        next: (value: any) => {
                            this.inscripcionForm.get('ConqId').setValue(value.PersId);
                            this.inscripcionForm.get('ConqNombres').setValue(value.PersNombres + ' ' + value.PersApellidoPaterno + ' ' + value.PersApellidoMaterno);
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
    }

    onNoClick(): void {
        this.dialogRef.close();
    }
}
