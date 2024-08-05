import { Injectable } from "@angular/core";
import { BehaviorSubject, map, Observable } from "rxjs";
import { UnsubscribeOnDestroyAdapter } from "src/app/shared/UnsubscribeOnDestroyAdapter";
import { Clase, InscripcionList, Tutor } from "../models";
import { RepositoryService } from "../service/repository.service";
import Swal from "sweetalert2";
@Injectable()
export class InscripcionService extends UnsubscribeOnDestroyAdapter {
    isTblLoading = true;
    dataChange: BehaviorSubject<InscripcionList[]> = new BehaviorSubject<InscripcionList[]>([]);
    dialogData: any;

    constructor(
        private repositoryService: RepositoryService
    ) {
        super();
    }

    get data(): InscripcionList[] {
        return this.dataChange.value;
    }

    getDialogData() {
        return this.dialogData;
    }

    getAllInscripciones(): void {
        this.repositoryService.GetInscripciones().subscribe({
            next: (value: any) => {
                this.dataChange.next(value);
            },
            error: (error: any) => {
                Swal.fire({
                    title: 'Error!',
                    text: 'Error al obtener la lista de inscripciones, intente de nuevo más tarde.',
                    icon: 'error',
                    confirmButtonText: 'Ok'
                });
            },
            complete: () => {
                this.isTblLoading = false;
            }
        })
    }

    add(data: any): void {
        this.repositoryService.SaveInscripcion(data).subscribe({
            next: (value: any) => {
                console.log(value)
                Swal.fire({
                    icon: "success",
                    title: value,
                    showConfirmButton: true,
                });
            },
            error: (error: any) => {
                Swal.fire({
                    title: 'Error!',
                    text: error,
                    icon: 'error',
                    confirmButtonText: 'Ok'
                });
            }
        })
    }
}
