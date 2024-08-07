import { Component, ElementRef, Inject, OnInit, ViewChild } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from "@angular/material/dialog";
import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { fromEvent } from "rxjs";
import { SelectionModel } from "@angular/cdk/collections";
import { UnsubscribeOnDestroyAdapter } from "src/app/shared/UnsubscribeOnDestroyAdapter";
import { ConquistadorList } from "src/app/core/models/ConquistadorList";
import { RepositoryService } from "src/app/core/service/repository.service";
import { ConquistadorService } from "src/app/core/repositories/conquistador.service";
import { ConquistadorDataSource } from "src/app/core/dataSource/ConquistadorList.datasource";
import { UsuarioService } from "src/app/core/repositories";
import { Usuario } from "src/app/core/models";
import { UsuarioDataSource } from "src/app/core/dataSource/Usuario.datasource";
@Component({
    selector: "app-registro",
    templateUrl: "./usuarios-dialog.component.html",
    styleUrls: [],
})
export class UsuariosDialogComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
    displayedColumns = [
        "usuario",
        "nombre",
        "actions",
    ];
    usuariosDataBase: UsuarioService | null;
    dataSource: UsuarioDataSource | null;
    selection = new SelectionModel<Usuario>(true, []);
    index: number;
    id: number;
    conquistador: Usuario | null;
    @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
    @ViewChild(MatSort, { static: true }) sort: MatSort;
    @ViewChild("filter", { static: true }) filter: ElementRef;

    constructor(
        public dialogRef: MatDialogRef<UsuariosDialogComponent>,
        public httpClient: HttpClient,
        public dialog: MatDialog,
        public repositoryService: RepositoryService,
        public usuarioService: UsuarioService,
        @Inject(MAT_DIALOG_DATA) public data: any,
    ) {
        super();
    }

    ngOnInit() {
        this.loadData();
    }

    public loadData() {
        this.usuariosDataBase = new UsuarioService(this.repositoryService);
        this.dataSource = new UsuarioDataSource(
            this.usuariosDataBase,
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
        await this.usuarioService.SetConqId(row.ConqId);
    }

    selectUsuario(row){
        this.usuarioService.setUsuario(row);
    }
}