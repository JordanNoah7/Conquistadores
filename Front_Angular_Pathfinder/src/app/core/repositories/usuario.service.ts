import { Injectable } from "@angular/core";
import { BehaviorSubject, map, Observable } from "rxjs";
import { UnsubscribeOnDestroyAdapter } from "src/app/shared/UnsubscribeOnDestroyAdapter";
import { ConquistadorList, Usuario } from "../models";
import { RepositoryService } from "../service/repository.service";
import Swal from "sweetalert2";
@Injectable()
export class UsuarioService extends UnsubscribeOnDestroyAdapter {
    isTblLoading = true;
    dataChange: BehaviorSubject<Usuario[]> = new BehaviorSubject<Usuario[]>([]);
    dialogData: any;

    constructor(
        private repositoryService: RepositoryService
    ) {
        super();
    }

    get data(): Usuario[] {
        return this.dataChange.value;
    }

    getDialogData() {
        return this.dialogData;
    }

    getAllUsuarios(): void {
        this.repositoryService.GetUsuarios().subscribe({
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

    setUsuario(data: any) {
        this.dialogData = data;
    }
}
