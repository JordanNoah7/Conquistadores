import { BehaviorSubject, map, merge, Observable, of } from "rxjs";
import { Usuario, UsuarioRol } from "../models";
import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { DataSource } from "@angular/cdk/collections";
import { UsuarioService } from "../repositories/usuario.service";
import { UsuarioRolService } from "../repositories";

export class RolUsuarioDataSource extends DataSource<UsuarioRol> {
    filterChange = new BehaviorSubject("");
    filteredData: UsuarioRol[] = [];
    renderedData: UsuarioRol[] = [];

    constructor(
        public usuarioService: UsuarioRolService,
        public paginator: MatPaginator,
        public _sort: MatSort,
        public RoleId: number
    ) {
        super();
        this.filterChange.subscribe(() => (this.paginator.pageIndex = 0));
    }

    get filter(): string {
        return this.filterChange.value;
    }
    set filter(filter: string) {
        this.filterChange.next(filter);
    }

    connect(): Observable<UsuarioRol[]> {
        debugger;
        console.log(this.RoleId);
        const displayDataChanges = [
            this.usuarioService.dataChange,
            this._sort.sortChange,
            this.filterChange,
            this.paginator.page,
        ];
        if(!this.RoleId || this.RoleId === 0){
            // this.usuarioService.isTblLoading = false;
            return of([]);
        }
        this.usuarioService.getAllRolUsuarios(this.RoleId);
        return merge(...displayDataChanges).pipe(
            map(() => {
                this.filteredData = this.usuarioService.data
                    .slice()
                    .filter((usuario: UsuarioRol) => {
                        const searchStr = (
                            usuario.UsuaUsuario +
                            usuario.PersNombres +
                            usuario.AudiUserCrea
                        ).toLowerCase();
                        return searchStr.indexOf(this.filter.toLowerCase()) !== -1;
                    });
                const sortedData = this.sortData(this.filteredData.slice());
                const startIndex = this.paginator.pageIndex * this.paginator.pageSize;
                this.renderedData = sortedData.splice(
                    startIndex,
                    this.paginator.pageSize
                );
                return this.renderedData;
            })
        );
    }

    disconnect() { }

    sortData(data: UsuarioRol[]): UsuarioRol[] {
        if (!this._sort.active || this._sort.direction === "") {
            return data;
        }
        return data.sort((a, b) => {
            let propertyA: number | string | Date = "";
            let propertyB: number | string | Date = "";
            switch (this._sort.active) {
                case "id":
                    [propertyA, propertyB] = [a.UsuaId, b.UsuaId];
                    break;
                case "nombres":
                    [propertyA, propertyB] = [a.PersNombres, b.PersNombres];
                    break;
                case "usuario":
                    [propertyA, propertyB] = [a.UsuaUsuario, b.UsuaUsuario];
                    break;
                case "fecha":
                    [propertyA, propertyB] = [a.AudiFechCrea, b.AudiFechCrea];
                    break;
                case "creador":
                    [propertyA, propertyB] = [a.AudiUserCrea, b.AudiUserCrea];
                    break;
            }
            const valueA = isNaN(+propertyA) ? propertyA : +propertyA;
            const valueB = isNaN(+propertyB) ? propertyB : +propertyB;
            return (
                (valueA < valueB ? -1 : 1) * (this._sort.direction === "asc" ? 1 : -1)
            );
        });
    }
}