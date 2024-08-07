import { Injectable } from "@angular/core";
import { BehaviorSubject, map, Observable } from "rxjs";
import { UnsubscribeOnDestroyAdapter } from "src/app/shared/UnsubscribeOnDestroyAdapter";
import { ConquistadorList, Usuario, UsuarioRol } from "../models";
import { RepositoryService } from "../service/repository.service";
import Swal from "sweetalert2";
@Injectable()
export class UsuarioRolService extends UnsubscribeOnDestroyAdapter {
    isTblLoading = true;
    dataChange: BehaviorSubject<UsuarioRol[]> = new BehaviorSubject<UsuarioRol[]>([]);
    dialogData: any;

    constructor(
        private repositoryService: RepositoryService
    ) {
        super();
    }

    get data(): UsuarioRol[] {
        return this.dataChange.value;
    }

    getDialogData() {
        return this.dialogData;
    }

    getAllRolUsuarios(RoleId: number): void {
        this.repositoryService.GetUsuariosByRol(RoleId).subscribe({
            next: (value: any) => {
                console.log(value);
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

    SetConqId(id: number) {
        this.dialogData = id;
    }

    public saveRolUsuarios(data: any): Observable<any> {
        return this.repositoryService.SaveConquistador(data).pipe(
            map(response => {
                return response;
            })
        )
    }
}
