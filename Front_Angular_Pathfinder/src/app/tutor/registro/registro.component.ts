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
import { TutorDataSource } from "src/app/core/dataSource/Tutor.datasource";
import { TutorService } from "src/app/core/repositories";
import { Tutor } from "src/app/core/models";
@Component({
    selector: "app-registro",
    templateUrl: "./registro.component.html",
    styleUrls: [],
})
export class RegistroComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
    displayedColumns = [
        "select",
        "id",
        "dni",
        "tutor",
        "correos",
        "moviles",
        "actions",
    ];
    tutorDataBase: TutorService | null;
    dataSource: TutorDataSource | null;
    selection = new SelectionModel<Tutor>(true, []);
    index: number;
    id: number;
    tutor: Tutor | null;
    @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
    @ViewChild(MatSort, { static: true }) sort: MatSort;
    @ViewChild("filter", { static: true }) filter: ElementRef;

    constructor(
        public httpClient: HttpClient,
        public dialog: MatDialog,
        public repositoryService: RepositoryService,
        public tutorService: TutorService,
        private router: Router,
    ) {
        super();
    }

    ngOnInit() {
        this.loadData();
    }

    public loadData() {
        this.tutorDataBase = new TutorService(this.repositoryService);
        this.dataSource = new TutorDataSource(
            this.tutorDataBase,
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

    isAllSelected() {
        const numSelected = this.selection.selected.length;
        const numRows = this.dataSource.renderedData.length;
        return numSelected === numRows;
    }

    masterToggle() {
        this.isAllSelected()
            ? this.dataSource.renderedData.forEach((row) =>
                this.selection.deselect(row)
            )
            : this.dataSource.renderedData.forEach((row) =>
                this.selection.select(row)
            );
    }

    addNew() {
        this.router.navigate(['/tutor/new']);
    }

    editCall(row) {
        this.router.navigate(['/tutor/edit',
            {
                T: row.PersId,
            },
        ]);
    }

    deleteItem(row) {
        //     this.id = row.id;
        //     let tempDirection;
        //     if (localStorage.getItem("isRtl") === "true") {
        //         tempDirection = "rtl";
        //     } else {
        //         tempDirection = "ltr";
        //     }
        //     const dialogRef = this.dialog.open(DeleteDialogComponent, {
        //         data: row,
        //         direction: tempDirection,
        //     });
        //     this.subs.sink = dialogRef.afterClosed().subscribe((result) => {
        //         if (result === 1) {
        //             const foundIndex = this.conquistadores.dataChange.value.findIndex(
        //                 (x) => x.id === this.id
        //             );
        //             // for delete we use splice in order to remove single object from DataService
        //             this.conquistadores.dataChange.value.splice(foundIndex, 1);
        //             this.refreshTable();
        //             this.showNotification(
        //                 "snackbar-danger",
        //                 "Delete Record Successfully...!!!",
        //                 "bottom",
        //                 "center"
        //             );
        //         }
        //     });
    }

    private refreshTable() {
        //     this.paginator._changePageSize(this.paginator.pageSize);
    }

    removeSelectedRows() {
        //     const totalSelect = this.selection.selected.length;
        //     this.selection.selected.forEach((item) => {
        //         const index: number = this.dataSource.renderedData.findIndex(
        //             (d) => d === item
        //         );
        //         this.conquistadores.dataChange.value.splice(index, 1);
        //         this.refreshTable();
        //         this.selection = new SelectionModel<Staff>(true, []);
        //     });
        //     this.showNotification(
        //         "snackbar-danger",
        //         totalSelect + " Record Delete Successfully...!!!",
        //         "bottom",
        //         "center"
        //     );
    }

    showNotification(colorName, text, placementFrom, placementAlign) {
        //     this.snackBar.open(text, "", {
        //         duration: 2000,
        //         verticalPosition: placementFrom,
        //         horizontalPosition: placementAlign,
        //         panelClass: colorName,
        //     });
    }
}