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
import { TutorService } from "src/app/core/repositories";
import { Tutor } from "src/app/core/models";
import { TutorModalDataSource } from "src/app/core/dataSource/TutorModal.datasource";
@Component({
    selector: "app-registro",
    templateUrl: "./tutores-dialog.component.html",
    styleUrls: [],
})
export class TutoresDialogComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
    displayedColumns = [
        "id",
        "dni",
        "tutor",
        "actions",
    ];
    tutoresDataBase: TutorService | null;
    dataSource: TutorModalDataSource | null;
    selection = new SelectionModel<Tutor>(true, []);
    index: number;
    id: number;
    conquistador: Tutor | null;
    sexo = "";
    @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
    @ViewChild(MatSort, { static: true }) sort: MatSort;
    @ViewChild("filter", { static: true }) filter: ElementRef;

    constructor(
        public dialogRef: MatDialogRef<TutoresDialogComponent>,
        public httpClient: HttpClient,
        public dialog: MatDialog,
        public repositoryService: RepositoryService,
        public tutorService: TutorService,
        private router: Router,
        @Inject(MAT_DIALOG_DATA) public data: any,
    ) {
        super();
        this.sexo = data.sexo;
    }

    ngOnInit() {
        this.loadData();
    }

    public loadData() {
        debugger;
        this.tutoresDataBase = new TutorService(this.repositoryService);
        this.dataSource = new TutorModalDataSource(
            this.tutoresDataBase,
            this.paginator,
            this.sort,
            this.sexo
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

    getTutor(row){
        this.tutorService.SetTutor(row);
    }
}