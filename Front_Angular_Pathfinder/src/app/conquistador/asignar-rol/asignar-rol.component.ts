import { Component, ElementRef, OnInit, ViewChild } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { MatDialog } from "@angular/material/dialog";
import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { MatSnackBar } from "@angular/material/snack-bar";
import { fromEvent } from "rxjs";
import { SelectionModel } from "@angular/cdk/collections";
import { UnsubscribeOnDestroyAdapter } from "src/app/shared/UnsubscribeOnDestroyAdapter";
import { RepositoryService } from "src/app/core/service/repository.service";
import { InscripcionService } from "src/app/core/repositories";
import { InscripcionList, Rol } from "src/app/core/models";
import { InscripcionListDataSource } from "src/app/core/dataSource/InscripcionList.datasource";
import { UntypedFormBuilder, UntypedFormGroup, Validators } from "@angular/forms";
@Component({
    selector: "app-asignar-rol",
    templateUrl: "./asignar-rol.component.html",
    styleUrls: [],
})
export class AsignarRolComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
    displayedColumns = [
        "dni",
        "conquistador",
        "unidad",
        "cargo",
        "clase",
        "actions",
    ];
    asignarRolDataBase: InscripcionService | null;
    dataSource: InscripcionListDataSource | null;
    selection = new SelectionModel<InscripcionList>(true, []);
    index: number;
    id: number;
    isSearching: false;
    isSaving: false;
    costo: number;
    asignarRol: InscripcionList | null;
    rolesList: Rol[];
    roleForm: UntypedFormGroup = this.fb.group({
        RoleId: [0, [Validators.required]],
    });
    @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
    @ViewChild(MatSort, { static: true }) sort: MatSort;
    @ViewChild("filter", { static: true }) filter: ElementRef;

    constructor(
        public httpClient: HttpClient,
        public dialog: MatDialog,
        public repositoryService: RepositoryService,
        public inscripcionService: InscripcionService,
        private snackBar: MatSnackBar,
        private fb: UntypedFormBuilder,
    ) {
        super();
    }

    onSubmit(){

    }

    ngOnInit() {
        this.GetRoles();
        this.loadData();
    }

    GetRoles() {
        this.repositoryService.GetRoles().subscribe({
            next: (value: any) => {
                this.rolesList = value;
            },
            error: (error: any) => {
                this.showNotification('error-snackbar', error, 'bottom', 'center');
            }
        });
    }

    public loadData() {
        this.asignarRolDataBase = new InscripcionService(this.repositoryService);
        this.dataSource = new InscripcionListDataSource(
            this.asignarRolDataBase,
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

    showNotification(colorName, text, placementFrom, placementAlign) {
        this.snackBar.open(text, "", {
            duration: 2000,
            verticalPosition: placementFrom,
            horizontalPosition: placementAlign,
            panelClass: colorName,
        });
    }

    addNew() {

    }
}