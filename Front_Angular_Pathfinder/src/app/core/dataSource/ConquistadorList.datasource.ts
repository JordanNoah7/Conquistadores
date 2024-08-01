import { BehaviorSubject, map, merge, Observable } from "rxjs";
import { ConquistadorList } from "../models";
import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { DataSource } from "@angular/cdk/collections";
import { ConquistadorService } from "../repositories/conquistador.service";

export class ConquistadorDataSource extends DataSource<ConquistadorList> {
    filterChange = new BehaviorSubject("");
    filteredData: ConquistadorList[] = [];
    renderedData: ConquistadorList[] = [];

    constructor(
        public conquistadorService: ConquistadorService,
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

    connect(): Observable<ConquistadorList[]> {
        const displayDataChanges = [
            this.conquistadorService.dataChange,
            this._sort.sortChange,
            this.filterChange,
            this.paginator.page,
        ];
        this.conquistadorService.getAllConquistadorList();
        return merge(...displayDataChanges).pipe(
            map(() => {
                this.filteredData = this.conquistadorService.data
                    .slice()
                    .filter((conquistador: ConquistadorList) => {
                        const searchStr = (
                            conquistador.ConqDni +
                            conquistador.ConqNombres +
                            conquistador.ConqApellidoPaterno +
                            conquistador.ConqApellidoMaterno +
                            conquistador.ConqClase +
                            conquistador.ConqUnidad
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

    sortData(data: ConquistadorList[]): ConquistadorList[] {
        if (!this._sort.active || this._sort.direction === "") {
            return data;
        }
        return data.sort((a, b) => {
            let propertyA: number | string = "";
            let propertyB: number | string = "";
            switch (this._sort.active) {
                case "id":
                    [propertyA, propertyB] = [a.ConqId, b.ConqId];
                    break;
                case "dni":
                    [propertyA, propertyB] = [a.ConqDni, b.ConqDni];
                    break;
                case "conquistador":
                    [propertyA, propertyB] = [a.ConqNombres + ' ' + a.ConqApellidoPaterno + ' ' + a.ConqApellidoMaterno, b.ConqNombres + ' ' + b.ConqApellidoPaterno + ' ' + b.ConqApellidoMaterno];
                    break;
                case "unidad":
                    [propertyA, propertyB] = [a.ConqUnidad, b.ConqUnidad];
                    break;
                case "clase":
                    [propertyA, propertyB] = [a.ConqClase, b.ConqClase];
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