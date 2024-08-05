import { Component, ElementRef, Inject, OnInit, ViewChild } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from "@angular/material/dialog";
import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { fromEvent } from "rxjs";
import { SelectionModel } from "@angular/cdk/collections";
import { UnsubscribeOnDestroyAdapter } from "src/app/shared/UnsubscribeOnDestroyAdapter";
import { RepositoryService } from "src/app/core/service/repository.service";
import { Router } from "@angular/router";
import { ClaseService, UnidadService } from "src/app/core/repositories";
import { Clase, Unidad } from "src/app/core/models";
import { ClaseModalDataSource, UnidadModalDataSource } from "src/app/core/dataSource";
@Component({
    selector: "app-registro",
    templateUrl: "./unidad-dialog.component.html",
    styleUrls: [],
})
export class UnidadDialogComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
    displayedColumns = [
        "id",
        "img",
        "nombre",
        "descripcion",
        "actions",
    ];
    unidadesDataBase: UnidadService | null;
    dataSource: UnidadModalDataSource | null;
    selection = new SelectionModel<Clase>(true, []);
    index: number;
    id: number;
    unidad: Unidad | null;
    @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
    @ViewChild(MatSort, { static: true }) sort: MatSort;
    @ViewChild("filter", { static: true }) filter: ElementRef;

    constructor(
        public dialogRef: MatDialogRef<UnidadDialogComponent>,
        public httpClient: HttpClient,
        public dialog: MatDialog,
        public repositoryService: RepositoryService,
        public unidadService: UnidadService,
        private router: Router,
        @Inject(MAT_DIALOG_DATA) public data: any,
    ) {
        super();
    }

    ngOnInit() {
        this.loadData();
    }

    public loadData() {
        this.unidadesDataBase = new UnidadService(this.repositoryService);
        this.dataSource = new UnidadModalDataSource(
            this.unidadesDataBase,
            this.paginator,
            this.sort,
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

    selectUnidad(row) {
        this.unidadService.setUnidad(row);
    }
}