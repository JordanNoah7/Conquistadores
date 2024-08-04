import { BehaviorSubject, map, merge, Observable } from "rxjs";
import { Unidad } from "../models";
import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { DataSource } from "@angular/cdk/collections";
import { Filters } from "../models/filters";
import { UnidadService } from "../repositories";

export class UnidadModalDataSource extends DataSource<Unidad> {
    filterChange = new BehaviorSubject("");
    filteredData: Unidad[] = [];
    renderedData: Unidad[] = [];
    filtros: Filters;

    constructor(
        public unidadService: UnidadService,
        public paginator: MatPaginator,
        public _sort: MatSort,
    ) {
        super();
        this.filterChange.subscribe(() => (this.paginator.pageIndex = 0));
        this.filtros = new Filters();
    }

    get filter(): string {
        return this.filterChange.value;
    }
    set filter(filter: string) {
        this.filterChange.next(filter);
    }

    connect(): Observable<Unidad[]> {
        const displayDataChanges = [
            this.unidadService.dataChange,
            this._sort.sortChange,
            this.filterChange,
            this.paginator.page,
        ];
        this.unidadService.getAllUnidades();
        return merge(...displayDataChanges).pipe(
            map(() => {
                this.filteredData = this.unidadService.data
                    .slice()
                    .filter((unidad: Unidad) => {
                        const searchStr = (
                            unidad.UnidId +
                            unidad.UnidNombre +
                            unidad.UnidDescripcion +
                            unidad.UnidImagen
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

    sortData(data: Unidad[]): Unidad[] {
        if (!this._sort.active || this._sort.direction === "") {
            return data;
        }
        return data.sort((a, b) => {
            let propertyA: number | string = "";
            let propertyB: number | string = "";
            switch (this._sort.active) {
                case "id":
                    [propertyA, propertyB] = [a.UnidId, b.UnidId];
                    break;
                case "nombre":
                    [propertyA, propertyB] = [a.UnidNombre, b.UnidNombre];
                    break;
                case "descripcion":
                    [propertyA, propertyB] = [a.UnidDescripcion, b.UnidDescripcion];
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