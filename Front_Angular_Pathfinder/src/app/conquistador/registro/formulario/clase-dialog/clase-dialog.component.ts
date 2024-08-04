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
import { ClaseService, TutorService } from "src/app/core/repositories";
import { Clase, Tutor } from "src/app/core/models";
import { TutorModalDataSource } from "src/app/core/dataSource/TutorModal.datasource";
import { ClaseModalDataSource } from "src/app/core/dataSource";
@Component({
    selector: "app-registro",
    templateUrl: "./clase-dialog.component.html",
    styleUrls: [],
})
export class ClaseDialogComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
    displayedColumns = [
        "id",
        "img",
        "nombre",
        "descripcion",
        "actions",
    ];
    clasesDataBase: ClaseService | null;
    dataSource: ClaseModalDataSource | null;
    selection = new SelectionModel<Clase>(true, []);
    index: number;
    id: number;
    clase: Clase | null;
    @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
    @ViewChild(MatSort, { static: true }) sort: MatSort;
    @ViewChild("filter", { static: true }) filter: ElementRef;

    constructor(
        public dialogRef: MatDialogRef<ClaseDialogComponent>,
        public httpClient: HttpClient,
        public dialog: MatDialog,
        public repositoryService: RepositoryService,
        public claseService: ClaseService,
        private router: Router,
        @Inject(MAT_DIALOG_DATA) public data: any,
    ) {
        super();
    }

    ngOnInit() {
        this.loadData();
    }

    public loadData() {
        debugger;
        this.clasesDataBase = new ClaseService(this.repositoryService);
        this.dataSource = new ClaseModalDataSource(
            this.clasesDataBase,
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

    selectClass(row){
        this.claseService.setClase(row);
    }
}