import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";
import { UnsubscribeOnDestroyAdapter } from "src/app/shared/UnsubscribeOnDestroyAdapter";
import { ConquistadorList } from "../models";
import { RepositoryService } from "../service/repository.service";
import Swal from "sweetalert2";
@Injectable()
export class ConquistadoresService extends UnsubscribeOnDestroyAdapter {
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
                    text: 'Error al obtener la lista de conquistadores, intente de nuevo más tarde.',
                    icon: 'error',
                    confirmButtonText: 'Cool'
                });
            },
            complete: () => {
                this.isTblLoading = false;
            }
        })
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
