import { BehaviorSubject, map, merge, Observable } from "rxjs";
import { Clase } from "../models";
import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { DataSource } from "@angular/cdk/collections";
import { Filters } from "../models/filters";
import { ClaseService } from "../repositories/clase.service";

export class ClaseModalDataSource extends DataSource<Clase> {
    filterChange = new BehaviorSubject("");
    filteredData: Clase[] = [];
    renderedData: Clase[] = [];
    filtros: Filters;

    constructor(
        public claseService: ClaseService,
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

    connect(): Observable<Clase[]> {
        const displayDataChanges = [
            this.claseService.dataChange,
            this._sort.sortChange,
            this.filterChange,
            this.paginator.page,
        ];
        this.claseService.getAllClases();
        return merge(...displayDataChanges).pipe(
            map(() => {
                this.filteredData = this.claseService.data
                    .slice()
                    .filter((clase: Clase) => {
                        const searchStr = (
                            clase.ClasId +
                            clase.ClasNombre +
                            clase.ClasDescripcion +
                            clase.ClasImagen
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

    sortData(data: Clase[]): Clase[] {
        if (!this._sort.active || this._sort.direction === "") {
            return data;
        }
        return data.sort((a, b) => {
            let propertyA: number | string = "";
            let propertyB: number | string = "";
            switch (this._sort.active) {
                case "id":
                    [propertyA, propertyB] = [a.ClasId, b.ClasId];
                    break;
                case "nombre":
                    [propertyA, propertyB] = [a.ClasNombre, b.ClasNombre];
                    break;
                case "descripcion":
                    [propertyA, propertyB] = [a.ClasDescripcion, b.ClasDescripcion];
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