import { Injectable } from "@angular/core";
import { BehaviorSubject, map, Observable } from "rxjs";
import { UnsubscribeOnDestroyAdapter } from "src/app/shared/UnsubscribeOnDestroyAdapter";
import { ConquistadorList } from "../models";
import { RepositoryService } from "../service/repository.service";
import Swal from "sweetalert2";
@Injectable()
export class ConquistadorService extends UnsubscribeOnDestroyAdapter {
    isTblLoading = true;
    dataChange: BehaviorSubject<ConquistadorList[]> = new BehaviorSubject<ConquistadorList[]>([]);
    dialogData: any;

    constructor(
        private repositoryService: RepositoryService
    ) {
        super();
    }

    get data(): ConquistadorList[] {
        return this.dataChange.value;
    }

    getDialogData() {
        return this.dialogData;
    }

    getAllConquistadorList(): void {
        this.repositoryService.GetConquistadores().subscribe({
            next: (value: any) => {
                this.dataChange.next(value);
            },
            error: (error: any) => {
                Swal.fire({
                    title: 'Error!',
                    text: error,
                    icon: 'error',
                    confirmButtonText: 'Ok'
                });
            },
            complete: () => {
                this.isTblLoading = false;
            }
        })
    }

    setConqId(id: number) {
        this.dialogData = id;
    }

    public getConquistadorById(id: number): Observable<any> {
        return this.repositoryService.GetConquistadoresById(id).pipe(
            map(response => {
                return response.conquistadorDTO;
            })
        );
    }

    addConquistador(conquistador: ConquistadorList): void {
        this.dialogData = conquistador;
    }

    updateConquistador(conquistador: ConquistadorList): void {
        this.dialogData = conquistador;
    }

    deleteConquistador(id: number): void {
    }
}
