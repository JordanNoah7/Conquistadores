import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { CoreService } from '../core.service';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { catchError, map, Observable, tap, throwError } from 'rxjs';

@Injectable()
export class GeneralService {

    private url: string = '';

    constructor(
        private core: CoreService,
        private http: HttpClient,
        private router: Router
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
}
