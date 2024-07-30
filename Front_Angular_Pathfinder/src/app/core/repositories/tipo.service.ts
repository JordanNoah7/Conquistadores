import { Injectable } from "@angular/core";
import { BehaviorSubject, map, Observable } from "rxjs";
import { UnsubscribeOnDestroyAdapter } from "src/app/shared/UnsubscribeOnDestroyAdapter";
import { ConquistadorList, Tipo } from "../models";
import { RepositoryService } from "../service/repository.service";
import Swal from "sweetalert2";
@Injectable()
export class TiposService extends UnsubscribeOnDestroyAdapter {
    isTblLoading = true;
    dialogData: any;

    constructor(
        private repositoryService: RepositoryService
    ) {
        super();
    }

    getDialogData() {
        return this.dialogData;
    }

    public GetTipos(payload: any): Observable<any> {
        return this.repositoryService.GetTipos(payload).pipe(
            map(response => {
                if (response) {
                    return response;
                } else {
                    return null;
                }
            })
        )
    }

    async addTipo(tipo: Tipo) {
        await this.repositoryService.AddTipos(tipo).subscribe({
            next: (value: any) => {
                this.dialogData = tipo;
            },
            error: (error: any) => {
                this.dialogData = null;
            }
        })
    }

    updateTipo(tipo: Tipo): void {
        this.dialogData = tipo;
    }

    deleteTipo(id: number): void {
    }
}
