import { HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class CoreService {

    getDefaultOptions = (): HttpHeaders => {
        const headers = new HttpHeaders();
        headers.set('Accept', 'application/json');
        headers.set('Content-Type', 'application/json');
        headers.set('Usuario', 'Prueba');
        return headers;
    }

    getUploadOptions = (): HttpHeaders => {
        const headers = new HttpHeaders();
        headers.set('Accept', 'application/json');
        //headers.delete('Content-Type');
        return headers;
    }

    getTextOptions = (): HttpHeaders => {
        const headers = new HttpHeaders();
        headers.set('Content-Type', 'text/plain');
        headers.delete('Pragma');
        return headers;
    }
}
