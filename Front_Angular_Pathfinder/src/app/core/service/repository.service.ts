import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { GeneralService } from "./api/general.service";

@Injectable()
export class RepositoryService {
    constructor(private requestService: GeneralService) { }

    // *Conquistadores
    public GetConquistador(): Observable<any> {
        return this.requestService.connectBackendGet("ObtenerConquistador").pipe(
            map(response => {
                if (!!response) {
                    return response.conquistadorDTO;
                }
                return null;
            }),
        );
    }

    public GetConquistadores(): Observable<any> {
        return this.requestService.connectBackendGet("ObtenerConquistadores").pipe(
            map(response => {
                if (!!response) {
                    return response;
                }
                return null;
            })
        );
    }

    public GetHijos(): Observable<any> {
        return this.requestService.connectBackendGet("ObtenerHijos").pipe(
            map(response => {
                if (!!response) {
                    return response;
                }
                return null;
            })
        );
    }

    // *Categorias
    public GetCategorias(): Observable<any> {
        return this.requestService.connectBackendGet("ObtenerCategorias").pipe(
            map(response => {
                if (!!response) {
                    return response;
                }
                return null;
            }),
        );
    }
}