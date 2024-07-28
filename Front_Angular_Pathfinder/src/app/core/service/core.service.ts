import { HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ContextService } from './context.service';
import { IpClientService } from './ipclient.service';
import { Request } from '../models/Request';

@Injectable()
export class CoreService {
    constructor(
        private contextService: ContextService,
        private ipClientService: IpClientService
    ) { }

    getDefaultOptions = (): HttpHeaders => {
        let request: Request = this.contextService.getRequest();
        const headers = new HttpHeaders({
            'Accept': 'application/json',
            'Content-Type': 'application/json',
            'requeststr': JSON.stringify(request)
        });
        return headers;
    }

    getUploadOptions = (): HttpHeaders => {
        const headers = new HttpHeaders({
            'Accept': 'application/json',
        });
        return headers;
    }

    getTextOptions = (): HttpHeaders => {
        const headers = new HttpHeaders({
            'Content-Type': 'text/plain'
        });
        return headers;
    }
}
