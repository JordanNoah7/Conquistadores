import { Component, OnInit, Input, Inject } from "@angular/core";
import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material/dialog";
import { ClaseDialogComponent } from "src/app/conquistador/registro/formulario/clase-dialog/clase-dialog.component";

@Component({
    selector: "app-modal-pdf",
    templateUrl: "./modal-pdf.component.html",
    styleUrls: ['./modal-pdf.component.scss'],
})
export class ModalPdfComponent implements OnInit {
    PDFbase64: string;
    title: string;
    fileName: string;

    constructor(
        public dialogRef: MatDialogRef<ClaseDialogComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any,
    ) { 
        this.PDFbase64 = data.base64Pdf;
        this.title = data.title;
        this.fileName = data.fileName;
    }

    ngOnInit(): void { }
}
