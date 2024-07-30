import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material/dialog";
import { Component, Inject } from "@angular/core";
import { UntypedFormControl, Validators, UntypedFormGroup, UntypedFormBuilder } from "@angular/forms";
import { formatDate } from "@angular/common";
import { TiposService } from "src/app/core/repositories";
import { Tipo } from "src/app/core/models";
@Component({
    selector: "app-form-dialog",
    templateUrl: "./tipo-dialog.component.html",
    styleUrls: [],
})
export class TipoDialogComponent {
    dialogTitle: string;
    tipoForm: UntypedFormGroup;
    tipo: Tipo;
    tabla: string;
    id: number;

    constructor(
        public dialogRef: MatDialogRef<TipoDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any,
        public tipoService: TiposService,
        private fb: UntypedFormBuilder
    ) {
        this.dialogTitle = data.dialogTitle;
        this.tabla = data.tabla;
        this.id = data.id;
        this.tipo = new Tipo();
        this.tipoForm = this.createTipoForm();
    }

    createTipoForm(): UntypedFormGroup {
        return this.fb.group({
            TipoTabla: [this.tabla],
            TipoId: [this.id],
            TipoDescripcion: [this.tipo.TipoDescripcion],
            TipoEstaActivo: [true],
        });
    }

    submit() {
        // emppty stuff
    }

    onNoClick(): void {
        this.dialogRef.close();
    }

    public confirmAdd(): void {
        this.tipoService.addTipo(this.tipoForm.getRawValue());
    }
}
