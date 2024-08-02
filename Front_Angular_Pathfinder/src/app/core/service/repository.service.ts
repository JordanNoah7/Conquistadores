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

    public GetConquistadorById(data: any): Observable<any> {
        return this.requestService.connectBackendPost("ObtenerConquistadorById", data).pipe(
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

    // *Tipos
    public AddTipos(payload: any): Observable<any> {
        return this.requestService.connectBackendPost("GuardarTipo", payload).pipe(
            map(response => {
                return response;
            })
        )
    }

    public GetTipos(payload: any): Observable<any> {
        return this.requestService.connectBackendPost("ObtenerTipos", payload).pipe(
            map(response => {
                if (!!response) {
                    return response;
                }
                return null;
            })
        )
    }

    // *Tutores
    public GetTutores(): Observable<any> {
        return this.requestService.connectBackendGet("ObtenerTutores").pipe(
            map(response => {
                if (!!response) {
                    return response;
                }
                return null;
            })
        )
    }

    public SaveTutor(data: any): Observable<any> {
        return this.requestService.connectBackendPost("GuardarTutor", data).pipe(
            map(response => {
                if (!!response) {
                    return response;
                }
                return null;
            })
        );
    }

    public GetTutor(data: any): Observable<any> {
        return this.requestService.connectBackendPost("ObtenerTutorById", data).pipe(
            map(response => {
                if (!!response) {
                    return response;
                }
                return null;
            })
        )
    }
}