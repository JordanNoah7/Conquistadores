import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CoreService } from '../core.service';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { Observable, throwError } from "rxjs";
import { catchError } from "rxjs/operators";
import { Request } from "../../models";

@Injectable()
export class GeneralUserService {

    private url: string = '';

    constructor(
        private core: CoreService,
        private http: HttpClient,
        private router: Router
    ) {
        this.url = environment.appsettings.http['/auth'].target;
        if (!(this.url.slice(this.url.length - 1) == '/')) {
            this.url += '/';
        }
    }

    public CallService = (payload: any, method: string) => new Promise<any>((resolve) =>
        this.http.post<any>((this.url + method), payload, { headers: this.core.getDefaultOptions() })
            .subscribe(
                data => resolve(data),
                err => resolve(err),
            )
    )

    public SendMail = (payload: Request) => new Promise<any>((resolve) =>
        this.http.post<any>((this.url + 'EnviarCorreo'), payload, { headers: this.core.getDefaultOptions() })
            .subscribe(
                data => resolve(data),
                err => resolve(err)
            )
    )

    public ChangePassword = (payload: any) => new Promise<any>((resolve) =>
        this.http.post<any>(this.url + 'CambiarContrasena', payload, { headers: this.core.getDefaultOptions() })
            .subscribe(
                data => resolve(data),
                err => resolve(null)
            )
    )
}
