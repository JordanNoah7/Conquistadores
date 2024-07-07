import { Injectable } from "@angular/core";
import { RequestService } from "./request.service";
import { ApiResponse, Request } from "../models";
import { ConquistadorDTO } from "../models/ConquistadorDTO";
import { Observable } from "rxjs";
import { GeneralService } from "./api";
import { map, tap } from "rxjs/operators";

@Injectable()
export class RepositoryService {
    constructor(private requestService: GeneralService) { }

    public GetConquistador(payload: Request): Observable<ConquistadorDTO> {
        return this.requestService.connectBackend("ObtenerConquistador", payload).pipe(
            map(response => {
                console.log(response);
                if (!!response) {
                    return response.conquistadorDTO;
                }
                return null;
            }),
        );
    }
}