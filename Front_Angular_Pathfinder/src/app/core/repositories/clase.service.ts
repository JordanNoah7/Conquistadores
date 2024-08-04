import { Injectable } from "@angular/core";
import { BehaviorSubject, map, Observable } from "rxjs";
import { UnsubscribeOnDestroyAdapter } from "src/app/shared/UnsubscribeOnDestroyAdapter";
import { Clase, Tutor } from "../models";
import { RepositoryService } from "../service/repository.service";
import Swal from "sweetalert2";
@Injectable()
export class ClaseService extends UnsubscribeOnDestroyAdapter {
    isTblLoading = true;
    dataChange: BehaviorSubject<Clase[]> = new BehaviorSubject<Clase[]>([]);
    dialogData: any;

    constructor(
        private repositoryService: RepositoryService
    ) {
        super();
    }

    get data(): Clase[] {
        return this.dataChange.value;
    }

    getDialogData() {
        return this.dialogData;
    }

    getAllClases(): void {
        this.repositoryService.GetClases().subscribe({
            next: (value: any) => {
                this.dataChange.next(value);
            },
            error: (error: any) => {
                Swal.fire({
                    title: 'Error!',
                    text: 'Error al obtener la lista de conquistadores, intente de nuevo más tarde.',
                    icon: 'error',
                    confirmButtonText: 'Ok'
                });
            },
            complete: () => {
                this.isTblLoading = false;
            }
        })
    }

    setClase(data: any){
        
    }
}
