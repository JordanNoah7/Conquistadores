import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { CoreService } from '../core.service';
import { environment } from 'src/environments/environment';
import { Observable, throwError } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { SessionService } from '../session.service';
import { RouterService } from '../router.service';
import { NotificationService } from '../notification.service';

@Injectable()
export class GeneralService {

    private url: string = '';

    constructor(
        private core: CoreService,
        private http: HttpClient,
        private router: RouterService,
        private sessionService: SessionService,
        private notificationService: NotificationService
    ) {
        this.url = environment.appsettings.http['/api'].target;
        if (!(this.url.slice(this.url.length - 1) == '/')) {
            this.url += '/';
        }
    }

    public CallService = (payload: any, method: string) => new Promise<any>((resolve) =>
        this.http.post<any>((this.url + method), payload, { headers: this.core.getDefaultOptions() })
            .subscribe(
                data => resolve(data),
                err => resolve(null)
            )
    )

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
                console.log(error);
                if (error.status === 401) {
                    this.notificationService.showSmallMessage(error.error, false);
                    this.sessionService.logout();
                }
                else if (error.status === 404) {
                    this.router.redirectToError404();
                } else if (error.status === 500) {
                    this.router.redirectToError500();
                } else if (error.error) {
                    console.error('Error:', error.error);
                }
                return throwError(error);
            })
        );
    }
}
