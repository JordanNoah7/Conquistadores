import { BehaviorSubject, map, merge, Observable } from "rxjs";
import { InscripcionList } from "../models";
import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { DataSource } from "@angular/cdk/collections";
import { InscripcionService } from "../repositories";

export class InscripcionListDataSource extends DataSource<InscripcionList> {
    filterChange = new BehaviorSubject("");
    filteredData: InscripcionList[] = [];
    renderedData: InscripcionList[] = [];

    constructor(
        public inscripcionService: InscripcionService,
        public paginator: MatPaginator,
        public _sort: MatSort
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

    connect(): Observable<InscripcionList[]> {
        const displayDataChanges = [
            this.inscripcionService.dataChange,
            this._sort.sortChange,
            this.filterChange,
            this.paginator.page,
        ];
        this.inscripcionService.getAllInscripciones();
        return merge(...displayDataChanges).pipe(
            map(() => {
                this.filteredData = this.inscripcionService.data
                    .slice()
                    .filter((inscripcion: InscripcionList) => {
                        const searchStr = (
                            inscripcion.PersDni +
                            inscripcion.PersNombres +
                            inscripcion.PersApellidoPaterno +
                            inscripcion.PersApellidoMaterno +
                            inscripcion.UnidNombre +
                            inscripcion.TipoDescripcion +
                            inscripcion.ClasNombre
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

    sortData(data: InscripcionList[]): InscripcionList[] {
        if (!this._sort.active || this._sort.direction === "") {
            return data;
        }
        return data.sort((a, b) => {
            let propertyA: number | string = "";
            let propertyB: number | string = "";
            switch (this._sort.active) {
                case "dni":
                    [propertyA, propertyB] = [a.PersDni, b.PersDni];
                    break;
                case "conquistador":
                    [propertyA, propertyB] = [a.PersNombres + ' ' + a.PersApellidoPaterno + ' ' + a.PersApellidoMaterno, b.PersNombres + ' ' + b.PersApellidoPaterno + ' ' + b.PersApellidoMaterno];
                    break;
                case "unidad":
                    [propertyA, propertyB] = [a.UnidNombre, b.UnidNombre];
                    break;
                case "cargo":
                    [propertyA, propertyB] = [a.TipoDescripcion, b.TipoDescripcion];
                    break;
                case "clase":
                    [propertyA, propertyB] = [a.ClasNombre, b.ClasNombre];
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