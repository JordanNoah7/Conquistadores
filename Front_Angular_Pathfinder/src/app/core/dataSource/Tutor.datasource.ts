import { BehaviorSubject, map, merge, Observable } from "rxjs";
import { Tutor } from "../models";
import { MatPaginator } from "@angular/material/paginator";
import { MatSort } from "@angular/material/sort";
import { DataSource } from "@angular/cdk/collections";
import { TutorService } from "../repositories";
import { Filters } from "../models/filters";

export class TutorDataSource extends DataSource<Tutor> {
    filterChange = new BehaviorSubject("");
    filteredData: Tutor[] = [];
    renderedData: Tutor[] = [];

    constructor(
        public tutorService: TutorService,
        public paginator: MatPaginator,
        public _sort: MatSort,
        private paterno1: string,
        private paterno2: string,
        private sexo: string,
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

    connect(): Observable<Tutor[]> {
        const displayDataChanges = [
            this.tutorService.dataChange,
            this._sort.sortChange,
            this.filterChange,
            this.paginator.page,
        ];
        let filtros = new Filters();
        filtros.Nombres = this.paterno1;
        filtros.Apellidos = this.paterno2;
        filtros.Tipo = this.sexo;
        this.tutorService.getAllTutor(filtros);
        return merge(...displayDataChanges).pipe(
            map(() => {
                this.filteredData = this.tutorService.data
                    .slice()
                    .filter((tutor: Tutor) => {
                        const searchStr = (
                            tutor.PersDni +
                            tutor.PersNombres +
                            tutor.PersApellidoPaterno +
                            tutor.PersApellidoMaterno
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

    sortData(data: Tutor[]): Tutor[] {
        if (!this._sort.active || this._sort.direction === "") {
            return data;
        }
        return data.sort((a, b) => {
            let propertyA: number | string = "";
            let propertyB: number | string = "";
            switch (this._sort.active) {
                case "id":
                    [propertyA, propertyB] = [a.PersId, b.PersId];
                    break;
                case "dni":
                    [propertyA, propertyB] = [a.PersDni, b.PersDni];
                    break;
                case "conquistador":
                    [propertyA, propertyB] = [a.PersNombres + ' ' + a.PersApellidoPaterno + ' ' + a.PersApellidoMaterno, b.PersNombres + ' ' + b.PersApellidoPaterno + ' ' + b.PersApellidoMaterno];
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