import { Injectable } from "@angular/core";
import { BehaviorSubject, map, Observable } from "rxjs";
import { UnsubscribeOnDestroyAdapter } from "src/app/shared/UnsubscribeOnDestroyAdapter";
import { Tutor } from "../models";
import { RepositoryService } from "../service/repository.service";
import Swal from "sweetalert2";
@Injectable()
export class TutorService extends UnsubscribeOnDestroyAdapter {
    isTblLoading = true;
    dataChange: BehaviorSubject<Tutor[]> = new BehaviorSubject<Tutor[]>([]);
    dialogData: any;

    constructor(
        private repositoryService: RepositoryService
    ) {
        super();
    }

    get data(): Tutor[] {
        return this.dataChange.value;
    }

    getDialogData() {
        return this.dialogData;
    }

    getAllTutor(): void {
        this.repositoryService.GetTutores().subscribe({
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

    public saveTutor(data: any): Observable<any> {
        return this.repositoryService.SaveTutor(data).pipe(
            map(response => {
                return response;
            })
        )
    }

    addTutor(tutor: Tutor): void {
        this.dialogData = tutor;
    }

    updateTutor(tutor: Tutor): void {
        this.dialogData = tutor;
    }

    deleteTutor(id: number): void {
    }
}
