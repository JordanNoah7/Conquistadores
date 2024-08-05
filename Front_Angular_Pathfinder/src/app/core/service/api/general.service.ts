import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { CoreService } from '../core.service';
import { environment } from 'src/environments/environment';
import { catchError, map, Observable, tap, throwError } from 'rxjs';
import { SessionService } from '../session.service';

@Injectable()
export class GeneralService {

    private url: string = '';

    constructor(
        private core: CoreService,
        private http: HttpClient,
        private sessionService: SessionService
    ) {
        this.url = environment.appsettings.http['/api'].target;
        if (!(this.url.slice(this.url.length - 1) == '/')) {
            this.url += '/';
        }
    }

    connectBackendPost(method: string, data: any): Observable<any> {
        return this.http.post<any>((this.url + method), data, { headers: this.core.getDefaultOptions(), observe: 'response' }).pipe(
            map((response: HttpResponse<any>) => {
                if (response.status === 200) {
                    return response.body;
                }
                throw new Error(`Unexpected response status: ${response.status}`);
            }),
            tap(response => {
                if (response.TiempoSesion > 0) {
                    this.sessionService.setMinutosDisponibles(response.TiempoSesion);
                }
            }),
            catchError((error: HttpErrorResponse) => {
                if (error.status === 404) {
                    console.error(error)
                } else if (error.status === 500) {
                    console.error(error);
                } else if (error) {
                    console.error('Error:', error.statusText);
                }
                console.log(error.error)
                return throwError(() => error.error.error);
            })
        );
    }

    connectBackendGet(method: string): Observable<any> {
        return this.http.get<any>((this.url + method), { headers: this.core.getDefaultOptions(), observe: 'response' }).pipe(
            map((response: HttpResponse<any>) => {
                if (response.status === 200) {
                    return response.body;
                }
                throw new Error(`Unexpected response status: ${response.status}`);
            }),
            tap(response => {
                if (response.TiempoSesion > 0) {
                    this.sessionService.setMinutosDisponibles(response.TiempoSesion);
                }
            }),
            catchError((error: HttpErrorResponse) => {
                if (error.status === 404) {
                    console.error(error)
                } else if (error.status === 500) {
                    console.error(error);
                } else if (error) {
                    console.error('Error:', error.statusText);
                }
                console.log(error.error)
                return throwError(() => error.error.error);
            })
        );
    }
}
