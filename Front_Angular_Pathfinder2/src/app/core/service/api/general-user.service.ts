import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { CoreService } from '../core.service';
import { environment } from 'src/environments/environment';
import { catchError, map, Observable, tap, throwError } from 'rxjs';
import { SessionService } from '../session.service';
import { ItemRequest } from '../../models/ItemRequest';

@Injectable()
export class GeneralUserService {

    private url: string = '';

    constructor(
        private core: CoreService,
        private http: HttpClient,
        private sessionService: SessionService
    ) {
        this.url = environment.appsettings.http['/auth'].target;
        if (!(this.url.slice(this.url.length - 1) == '/')) {
            this.url += '/';
        }
    }

    //TODO: Eliminar el CallService y solo usar connectBackend
    // public CallService = (payload: any, method: string) => new Promise<any>((resolve) => {
    //     this.http.post<any>((this.url + method), payload, { headers: this.core.getDefaultOptions() })
    //         .subscribe(
    //             data => resolve(data),
    //             err => resolve(null)
    //         )
    // })

    connectBackend(method: string, data: any): Observable<any> {
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
                console.log(error)
                if (error.status === 404) {
                    console.error(error)
                } else if (error.status === 500) {
                    console.error(error);
                } else if (error) {
                    console.error('Error:', error.statusText);
                }
                return throwError(() => error.error.error);
            })
        );
    }

    GetPublicKey(request: ItemRequest): Observable<any> {
        return this.http.post<any>((this.url + 'GetPublicKey'), { Request: request, TypeKey: "PEM" }, { headers: this.core.getDefaultOptions(), observe: 'response' }).pipe(
            map((response: HttpResponse<any>) => {
                if (response.status === 200) {
                    return response.body;
                }
                throw new Error(`Unexpected response status: ${response.status}`);
            }),
            catchError((error: HttpErrorResponse) => {
                if (error.status === 404) {
                    console.error(error)
                } else if (error.status === 500) {
                    console.error(error);
                } else if (error.error) {
                    console.error('Error:', error.error);
                }
                return throwError(() => error);
            })
        );
    }
}
