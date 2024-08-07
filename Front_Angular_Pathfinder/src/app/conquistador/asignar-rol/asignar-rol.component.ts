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
import { Rol, Usuario, UsuarioRol, Request } from "src/app/core/models";
import { UntypedFormBuilder, UntypedFormGroup, Validators } from "@angular/forms";
import { UsuarioService } from "src/app/core/repositories/usuario.service";
import { RolUsuarioDataSource } from "src/app/core/dataSource/RolUsuarios.datasource";
import Swal from "sweetalert2";
import { ConquistadorService, UsuarioRolService } from "src/app/core/repositories";
import { UsuariosDialogComponent } from "./usuarios-dialog/usuarios-dialog.component";
import { ContextService } from "src/app/core/service/context.service";
import { InstructorDialogComponent } from "./instructor-dialog/instructor-dialog.component";
import { ConsejeroDialogComponent } from "./consejero-dialog/consejero-dialog.component";
@Component({
    selector: "app-asignar-rol",
    templateUrl: "./asignar-rol.component.html",
    styleUrls: [],
})
export class AsignarRolComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
    displayedColumns = [
        "nombres",
        "usuario",
        "fecha",
        "creador",
        "actions",
    ];
    asignarRolDataBase: UsuarioRolService | null;
    dataSource: RolUsuarioDataSource | null;
    selection = new SelectionModel<Usuario>(true, []);
    index: number;
    id: number;
    isSearching = false;
    isSaving = false;
    isChange = false;
    costo: number;
    asignarRol: Usuario | null;
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
        public usuarioService: UsuarioService,
        private snackBar: MatSnackBar,
        private fb: UntypedFormBuilder,
        private conquistadorService: ConquistadorService,
        private contextService: ContextService,
    ) {
        super();
    }

    ngOnInit() {
        this.GetRoles();
        this.loadData();
        this.asignarRolDataBase.isTblLoading = false;
    }

    onSubmit() {
        if (this.isSearching) {
            return;
        }
        this.isSearching = true;
        this.id = this.roleForm.get('RoleId').value;
        if (!this.id || this.id === 0) {
            this.showNotification('success', 'Primero debe seleccionar un rol.', 'top', 'center');
            this.isSearching = false;
            return;
        }
        this.loadData();
        this.isSearching = false;
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
        this.asignarRolDataBase = new UsuarioRolService(this.repositoryService);
        this.dataSource = new RolUsuarioDataSource(
            this.asignarRolDataBase,
            this.paginator,
            this.sort,
            this.id
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
        if (this.isChange) {
            Swal.fire({
                text: "Tienes cambios sin guardar, ¿deseas cancelar sin guardar los cambios?",
                icon: "warning",
                showCancelButton: true,
                confirmButtonColor: "#3085d6",
                cancelButtonColor: "#d33",
                confirmButtonText: "Si",
                cancelButtonText: "No"
            }).then((result) => {
                if (result.isConfirmed) {
                    this.id = null;
                    this.roleForm.get('RoleId').setValue(0);
                    this.loadData();
                    this.asignarRolDataBase.isTblLoading = false;
                    this.isChange = false;
                }
            });
        } else {
            this.id = null;
            this.roleForm.get('RoleId').setValue(0);
            this.loadData();
            this.asignarRolDataBase.isTblLoading = false;
        }
    }

    private refreshTable() {
        this.paginator._changePageSize(this.paginator.pageSize);
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
        let dialogRef: any;
        switch (this.id) {
            case 1: //administrador
            case 2: //director
                dialogRef = this.dialog.open(UsuariosDialogComponent, {});
                this.subs.sink = dialogRef.afterClosed().subscribe((result) => {
                    if (result === 1) {
                        let usuario = this.usuarioService.getDialogData();
                        let u = this.asignarRolDataBase.dataChange.value.find(u => u.UsuaId == usuario.UsuaId);
                        let r = this.rolesList.find(r => r.RoleId == this.id);
                        if (u) {
                            Swal.fire({
                                title: 'Advertencia',
                                text: `Este usuario ya tiene el rol de ${r.RoleNombre}.`,
                                icon: 'warning',
                                confirmButtonText: 'Ok'
                            });
                        } else {
                            let request: Request = this.contextService.getRequest();
                            let nuevo = new UsuarioRol();
                            nuevo.RoleId = this.id;
                            nuevo.UsuaId = usuario.UsuaId;
                            nuevo.UsuaUsuario = usuario.UsuaUsuario;
                            nuevo.PersNombres = usuario.PersNombres;
                            nuevo.AudiFechCrea = new Date().toLocaleDateString('es-ES', {
                                year: 'numeric',
                                month: '2-digit',
                                day: '2-digit'
                            });
                            nuevo.AudiUserCrea = request.UsuaUsuario;
                            this.asignarRolDataBase.dataChange.value.unshift(
                                nuevo
                            );
                            this.isChange = true;
                            this.refreshTable();
                        }
                    }
                })
                break;
            case 3: //instructor
                dialogRef = this.dialog.open(InstructorDialogComponent, {
                    data: {
                        UsuaId: 0,
                        UsuaUsuario: '',
                        PersNombres: '',
                        ClasId: 0,
                        ClasNombre: '',
                        edit: false,
                    }
                });
                this.subs.sink = dialogRef.afterClosed().subscribe((result) => {
                    debugger;
                    if (result === 1) {
                        let usuario = this.usuarioService.getDialogData();
                        let u = this.asignarRolDataBase.dataChange.value.find(u => u.UsuaId == usuario.UsuaId);
                        let r = this.rolesList.find(r => r.RoleId == this.id);
                        if (u) {
                            Swal.fire({
                                title: 'Advertencia',
                                text: `Este usuario ya tiene el rol de ${r.RoleNombre}.`,
                                icon: 'warning',
                                confirmButtonText: 'Ok'
                            });
                        } else {
                            let request: Request = this.contextService.getRequest();
                            let nuevo = new UsuarioRol();
                            nuevo.RoleId = this.id;
                            nuevo.UsuaId = usuario.UsuaId;
                            nuevo.UsuaUsuario = usuario.UsuaUsuario;
                            nuevo.PersNombres = usuario.PersNombres;
                            nuevo.AudiFechCrea = new Date().toLocaleDateString('es-ES', {
                                year: 'numeric',
                                month: '2-digit',
                                day: '2-digit'
                            });
                            nuevo.AudiUserCrea = request.UsuaUsuario;
                            nuevo.ClasId = usuario.ClasId;
                            nuevo.ClasNombre = usuario.ClasNombre;
                            this.asignarRolDataBase.dataChange.value.unshift(
                                nuevo
                            );
                            this.isChange = true;
                            this.refreshTable();
                        }
                    }
                })
                break;
            case 4: //consejero
                dialogRef = this.dialog.open(ConsejeroDialogComponent, {
                    data: {
                        UsuaId: 0,
                        UsuaUsuario: '',
                        PersNombres: '',
                        UnidId: 0,
                        UnidNombre: '',
                        edit: false,
                    }
                });
                this.subs.sink = dialogRef.afterClosed().subscribe((result) => {
                    debugger;
                    if (result === 1) {
                        let usuario = this.usuarioService.getDialogData();
                        let u = this.asignarRolDataBase.dataChange.value.find(u => u.UsuaId == usuario.UsuaId);
                        let r = this.rolesList.find(r => r.RoleId == this.id);
                        if (u) {
                            Swal.fire({
                                title: 'Advertencia',
                                text: `Este usuario ya tiene el rol de ${r.RoleNombre}.`,
                                icon: 'warning',
                                confirmButtonText: 'Ok'
                            });
                        } else {
                            let request: Request = this.contextService.getRequest();
                            let nuevo = new UsuarioRol();
                            nuevo.RoleId = this.id;
                            nuevo.UsuaId = usuario.UsuaId;
                            nuevo.UsuaUsuario = usuario.UsuaUsuario;
                            nuevo.PersNombres = usuario.PersNombres;
                            nuevo.AudiFechCrea = new Date().toLocaleDateString('es-ES', {
                                year: 'numeric',
                                month: '2-digit',
                                day: '2-digit'
                            });
                            nuevo.AudiUserCrea = request.UsuaUsuario;
                            nuevo.UnidId = usuario.UnidId;
                            nuevo.UnidNombre = usuario.UnidNombre;
                            this.asignarRolDataBase.dataChange.value.unshift(
                                nuevo
                            );
                            this.isChange = true;
                            this.refreshTable();
                        }
                    }
                })
                break;
        }
    }

    saveAll() {
        console.log(this.asignarRolDataBase.dataChange.value)
    }

    editItem(row) {
        let dialogRef: any;
        switch (this.id) {
            case 3: //instructor
                dialogRef = this.dialog.open(InstructorDialogComponent, {
                    data: {
                        UsuaId: row.UsuaId,
                        UsuaUsuario: row.UsuaUsuario,
                        PersNombres: row.PersNombres,
                        ClasId: row.ClasId,
                        ClasNombre: row.ClasNombre,
                        edit: false,
                    }
                });
                this.subs.sink = dialogRef.afterClosed().subscribe((result) => {
                    debugger;
                    if (result === 1) {
                        let usuario = this.usuarioService.getDialogData();
                        let u = this.asignarRolDataBase.dataChange.value.find(u => u.UsuaId == usuario.UsuaId);
                        let r = this.rolesList.find(r => r.RoleId == this.id);
                        if (u) {
                            Swal.fire({
                                title: 'Advertencia',
                                text: `Este usuario ya tiene el rol de ${r.RoleNombre}.`,
                                icon: 'warning',
                                confirmButtonText: 'Ok'
                            });
                        } else {
                            let request: Request = this.contextService.getRequest();
                            let nuevo = new UsuarioRol();
                            nuevo.RoleId = this.id;
                            nuevo.UsuaId = usuario.UsuaId;
                            nuevo.UsuaUsuario = usuario.UsuaUsuario;
                            nuevo.PersNombres = usuario.PersNombres;
                            nuevo.AudiFechCrea = new Date().toLocaleDateString('es-ES', {
                                year: 'numeric',
                                month: '2-digit',
                                day: '2-digit'
                            });
                            nuevo.AudiUserCrea = request.UsuaUsuario;
                            nuevo.ClasId = usuario.ClasId;
                            nuevo.ClasNombre = usuario.ClasNombre;
                            this.asignarRolDataBase.dataChange.value.unshift(
                                nuevo
                            );
                            this.isChange = true;
                            this.refreshTable();
                        }
                    }
                })
                break;
            case 4: //consejero
                dialogRef = this.dialog.open(ConsejeroDialogComponent, {
                    data: {
                        UsuaId: row.UsuaId,
                        UsuaUsuario: row.UsuaUsuario,
                        PersNombres: row.PersNombres,
                        UnidId: row.UnidId,
                        UnidNombre: row.UnidNombre,
                        edit: true,
                    }
                });
                this.subs.sink = dialogRef.afterClosed().subscribe((result) => {
                    debugger;
                    if (result === 1) {
                        let usuario = this.usuarioService.getDialogData();
                        let u = this.asignarRolDataBase.dataChange.value.find(u => u.UsuaId == usuario.UsuaId);
                        let r = this.rolesList.find(r => r.RoleId == this.id);
                        if (u) {
                            Swal.fire({
                                title: 'Advertencia',
                                text: `Este usuario ya tiene el rol de ${r.RoleNombre}.`,
                                icon: 'warning',
                                confirmButtonText: 'Ok'
                            });
                        } else {
                            let request: Request = this.contextService.getRequest();
                            let nuevo = new UsuarioRol();
                            nuevo.RoleId = this.id;
                            nuevo.UsuaId = usuario.UsuaId;
                            nuevo.UsuaUsuario = usuario.UsuaUsuario;
                            nuevo.PersNombres = usuario.PersNombres;
                            nuevo.AudiFechCrea = new Date().toLocaleDateString('es-ES', {
                                year: 'numeric',
                                month: '2-digit',
                                day: '2-digit'
                            });
                            nuevo.AudiUserCrea = request.UsuaUsuario;
                            nuevo.UnidId = usuario.UnidId;
                            nuevo.UnidNombre = usuario.UnidNombre;
                            this.asignarRolDataBase.dataChange.value.unshift(
                                nuevo
                            );
                            this.isChange = true;
                            this.refreshTable();
                        }
                    }
                })
                break;
        }
    }

    deleteItem(row) {
        debugger;
        let u = this.asignarRolDataBase.dataChange.value.filter(u => u.UsuaId != row.UsuaId);
        this.asignarRolDataBase.dataChange.next(u);
        this.isChange = true;
        this.refreshTable();
    }
}