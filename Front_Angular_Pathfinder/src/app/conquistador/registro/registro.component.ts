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
import { ConquistadoresService } from "src/app/core/repositories/conquistador.service";
import { ConquistadorDataSource } from "src/app/core/dataSource/ConquistadorList.datasource";
import { Router } from "@angular/router";
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
        "conquistador",
        "unidad",
        "clase",
        "actions",
    ];
    conquistadoresDataBase: ConquistadoresService | null;
    dataSource: ConquistadorDataSource | null;
    selection = new SelectionModel<ConquistadorList>(true, []);
    index: number;
    id: number;
    conquistador: ConquistadorList | null;
    @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
    @ViewChild(MatSort, { static: true }) sort: MatSort;
    @ViewChild("filter", { static: true }) filter: ElementRef;

    constructor(
        public httpClient: HttpClient,
        public dialog: MatDialog,
        public repositoryService: RepositoryService,
        public conquistadorService: ConquistadoresService,
        private snackBar: MatSnackBar,
        private router: Router,
    ) {
        super();
    }

    ngOnInit() {
        this.loadData();
    }

    public loadData() {
        this.conquistadoresDataBase = new ConquistadoresService(this.repositoryService);
        this.dataSource = new ConquistadorDataSource(
            this.conquistadoresDataBase,
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
        this.router.navigate(['/conquistador/new']);
    }

    editCall(row) {
        this.router.navigate(['/conquistador/edit',
            {
                C: row.ConqId,
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