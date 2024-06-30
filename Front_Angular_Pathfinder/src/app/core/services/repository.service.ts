import { Injectable } from "@angular/core";
import { RequestService } from "./request.service";
import { ApiResponse, Request } from "../models";

@Injectable()
export class RepositoryService {
    constructor(private requestService: RequestService) { }

    public GetConquistador(payload: Request): Promise<any> {
        return new Promise<any>(async (resolve) => {
            const result: any = await this.requestService.SendRequestConquistador(payload, 'ObtenerConquistador');
            console.log(result);
            resolve(result);
        });
    }
}