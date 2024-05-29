import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CoreService } from '../core.service';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';

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

    public ObtenerCorreo = (payload: { USER_CodUsr: string | false; }) => new Promise<any>((resolve) =>
        this.http.post<any>('/auth/ObtenerCorreo', payload, { headers: this.core.getDefaultOptions() })
            .subscribe(
                data => resolve(data),
                err => resolve(null)
            )
    )

    public EnviarCorreo = (payload: any) => new Promise<any>((resolve) =>
        this.http.post<any>('/auth/EnviarCorreo', payload, { headers: this.core.getDefaultOptions() })
            .subscribe(
                data => resolve(data),
                err => resolve(null)
            )
    )

    public TokenTimeOut = () => {
        this.router.navigate(['/auth/login']);
    }
}
