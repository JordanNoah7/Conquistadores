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

    public SaveConquistador(data: any): Observable<any> {
        return this.requestService.connectBackendPost("GuardarConquistador", data).pipe(
            map(response => {
                if (!!response) {
                    return response;
                }
                return null;
            })
        );
    }

    public GetRegistro(data: any): Observable<any> {
        return this.requestService.connectBackendPost("ObtenerRegistro", data).pipe(
            map(response => {
                if (!!response) {
                    return response;
                }
                return null;
            })
        );
    }

    public GetFichaMedica(data: any): Observable<any> {
        return this.requestService.connectBackendPost("ObtenerFichaMedica", data).pipe(
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

    public GetTutoresBySexo(data: any): Observable<any> {
        return this.requestService.connectBackendPost("ObtenerTutores", data).pipe(
            map(response => {
                if (!!response) {
                    return response;
                }
                return null;
            })
        )
    }

    // *Clases
    public GetClases(): Observable<any> {
        return this.requestService.connectBackendGet("ObtenerClases").pipe(
            map(response => {
                if (!!response) {
                    return response;
                }
                return null;
            })
        )
    }

    public SaveClaseConquistador(data: any): Observable<any> {
        return this.requestService.connectBackendPost("GuardarClaseConquistador", data).pipe(
            map(response => {
                if (!!response) {
                    return response;
                }
                return null;
            })
        )
    }

    public AprobarClaseConquistador(data: any): Observable<any> {
        return this.requestService.connectBackendPost("AprobarClaseConquistador", data).pipe(
            map(response => {
                if (!!response) {
                    return response;
                }
                return null;
            })
        )
    }

    // *Unidades
    public GetUnidades(): Observable<any> {
        return this.requestService.connectBackendGet("ObtenerUnidades").pipe(
            map(response => {
                if (!!response) {
                    return response;
                }
                return null;
            })
        )
    }

    public SaveUnidadConquistador(data: any): Observable<any> {
        return this.requestService.connectBackendPost("GuardarUnidadConquistador", data).pipe(
            map(response => {
                if (!!response) {
                    return response;
                }
                return null;
            })
        )
    }

    // *Inscripciones
    public GetInscripciones(): Observable<any> {
        return this.requestService.connectBackendGet("ObtenerInscripciones").pipe(
            map(response => {
                if (!!response) {
                    return response;
                }
                return null;
            })
        )
    }

    public SaveInscripcion(data: any): Observable<any> {
        return this.requestService.connectBackendPost("GuardarInscripcion", data).pipe(
            map(response => {
                if (!!response) {
                    return response;
                }
                return null;
            })
        )
    }

    // *Parametros
    public GetValorParametro(data: any): Observable<any> {
        return this.requestService.connectBackendPost("ObtenerParametro", data).pipe(
            map(response => {
                if (!!response) {
                    return response.ParaValor;
                }
                return null;
            })
        )
    }

    // *Roles
    public GetRoles(): Observable<any> {
        return this.requestService.connectBackendGet("ObtenerRoles").pipe(
            map(response => {
                if (!!response) {
                    return response;
                }
                return null;
            })
        )
    }

    public GetUsuariosByRol(data: any): Observable<any> {
        return this.requestService.connectBackendPost("ObtenerUsuariosPorRol", data).pipe(
            map(response => {
                if (!!response) {
                    return response;
                }
                return null;
            })
        )
    }

    // *Usuarios
    public GetUsuarios(): Observable<any> {
        return this.requestService.connectBackendGet("ObtenerUsuarios").pipe(
            map(response => {
                if (!!response) {
                    return response;
                }
                return null;
            })
        )
    }
}