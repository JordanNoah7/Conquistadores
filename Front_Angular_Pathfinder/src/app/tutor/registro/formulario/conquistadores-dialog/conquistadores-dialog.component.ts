import { Component, ElementRef, Inject, OnInit, ViewChild } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from "@angular/material/dialog";
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
@Component({
    selector: "app-registro",
    templateUrl: "./conquistadores-dialog.component.html",
    styleUrls: [],
})
export class ConquistadoresDialogComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
    displayedColumns = [
        "id",
        "dni",
        "conquistador",
        "actions",
    ];
    conquistadoresDataBase: ConquistadorService | null;
    dataSource: ConquistadorDataSource | null;
    selection = new SelectionModel<ConquistadorList>(true, []);
    index: number;
    id: number;
    conquistador: ConquistadorList | null;
    @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
    @ViewChild(MatSort, { static: true }) sort: MatSort;
    @ViewChild("filter", { static: true }) filter: ElementRef;

    constructor(
        public dialogRef: MatDialogRef<ConquistadoresDialogComponent>,
        public httpClient: HttpClient,
        public dialog: MatDialog,
        public repositoryService: RepositoryService,
        public conquistadorService: ConquistadorService,
        @Inject(MAT_DIALOG_DATA) public data: any,
    ) {
        super();
    }

    ngOnInit() {
        this.loadData();
    }

    public loadData() {
        this.conquistadoresDataBase = new ConquistadorService(this.repositoryService);
        this.dataSource = new ConquistadorDataSource(
            this.conquistadoresDataBase,
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

    async getConquistador(row) {
        await this.conquistadorService.SetConqId(row.ConqId);
    }
}