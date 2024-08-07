import { Component, ElementRef, OnInit, ViewChild } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { MatDialog } from "@angular/material/dialog";
import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { MatSnackBar } from "@angular/material/snack-bar";
import { fromEvent } from "rxjs";
import { SelectionModel } from "@angular/cdk/collections";
import { UnsubscribeOnDestroyAdapter } from "src/app/shared/UnsubscribeOnDestroyAdapter";
import { ConquistadorList } from "src/app/core/models/ConquistadorList";
import { RepositoryService } from "src/app/core/service/repository.service";
import { ConquistadorService } from "src/app/core/repositories/conquistador.service";
import { ConquistadorDataSource } from "src/app/core/dataSource/ConquistadorList.datasource";
import { Router } from "@angular/router";
import { InscripcionService } from "src/app/core/repositories";
import { Filters, InscripcionList } from "src/app/core/models";
import { InscripcionListDataSource } from "src/app/core/dataSource/InscripcionList.datasource";
import { InscripcionDialogComponent } from "./inscripcion-dialog/inscripcion-dialog.component";
import { ModalPdfComponent } from "src/app/shared/components/modal-pdf/modal-pdf.component";
@Component({
    selector: "app-inscripcion",
    templateUrl: "./inscripcion.component.html",
    styleUrls: ['./inscripcion.component.scss'],
})
export class InscripcionComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
    displayedColumns = [
        "dni",
        "conquistador",
        "unidad",
        "cargo",
        "clase",
        "actions",
    ];
    inscripcionesDataBase: InscripcionService | null;
    dataSource: InscripcionListDataSource | null;
    selection = new SelectionModel<InscripcionList>(true, []);
    index: number;
    id: number;
    costo: number;
    inscripcion: InscripcionList | null;
    @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
    @ViewChild(MatSort, { static: true }) sort: MatSort;
    @ViewChild("filter", { static: true }) filter: ElementRef;

    constructor(
        public httpClient: HttpClient,
        public dialog: MatDialog,
        public repositoryService: RepositoryService,
        public inscripcionService: InscripcionService,
        private snackBar: MatSnackBar,
    ) {
        super();
    }

    ngOnInit() {
        this.getCosto();
        this.loadData();
    }

    public loadData() {
        debugger;
        this.inscripcionesDataBase = new InscripcionService(this.repositoryService);
        this.dataSource = new InscripcionListDataSource(
            this.inscripcionesDataBase,
            this.paginator,
            this.sort
        );
        this.subs.sink = fromEvent(this.filter.nativeElement, "keyup").subscribe(
            () => {
                if (!this.dataSource) {
                    return;
                }
                this.dataSource.filter = this.filter.nativeElement.value;
            }
        );
    }

    refresh() {
        this.loadData();
    }

    addNew() {
        const dialogRef = this.dialog.open(InscripcionDialogComponent, {
            data: {
                ConqId: 0,
                InscMonto: 0,
                costo: this.costo,
                nombres: '',
                edit: false,
            }
        });
        this.subs.sink = dialogRef.afterClosed().subscribe((result) => {
            this.refresh();
        })
    }

    showInscripcion(row) {
        this.repositoryService.GetRegistro(row.PersId).subscribe({
            next: (value: any) => {
                const dialogRef = this.dialog.open(ModalPdfComponent, {
                    data: {
                        base64Pdf: value,
                        title: 'Ficha de registro',
                        fileName: 'Ficha de registro - ' + row.PersNombres + ' ' + row.PersApellidoPaterno + ' ' + row.PersApellidoMaterno
                    }
                })
            },
            error: (error: any) => {
                this.showNotification('red', error, 500, 'center');
            }
        });
    }

    showFichaMedica(row) {
        this.repositoryService.GetFichaMedica(row.PersId).subscribe({
            next: (value: any) => {
                const dialogRef = this.dialog.open(ModalPdfComponent, {
                    data: {
                        base64Pdf: value,
                        title: 'Ficha de medica',
                        fileName: 'Ficha médica - ' + row.PersNombres + ' ' + row.PersApellidoPaterno + ' ' + row.PersApellidoMaterno
                    }
                })
            },
            error: (error: any) => {
                this.showNotification('red', error, 500, 'center');
            }
        });
    }

    payFee(row) {
        const dialogRef = this.dialog.open(InscripcionDialogComponent, {
            data: {
                ConqId: row.PersId,
                InscMonto: row.InscMonto,
                costo: this.costo,
                nombres: row.PersNombres + ' ' + row.PersApellidoPaterno + ' ' + row.PersApellidoMaterno,
                edit: true,
            }
        });
        this.subs.sink = dialogRef.afterClosed().subscribe((result) => {
            this.refresh();
        })
    }

    showNotification(colorName, text, placementFrom, placementAlign) {
        this.snackBar.open(text, "", {
            duration: 2000,
            verticalPosition: placementFrom,
            horizontalPosition: placementAlign,
            panelClass: colorName,
        });
    }

    async getCosto() {
        let filtros = new Filters();
        filtros.Nombres = 'CostoInscripcion';
        await this.repositoryService.GetValorParametro(filtros).subscribe({
            next: (value: any) => {
                this.costo = value;
            },
            error: (error: any) => {
                this.costo = 0;
            }
        })
    }
}