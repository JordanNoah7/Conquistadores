import { Request } from '../models/Request';
import { Injectable } from '@angular/core';
import { RouterService } from './router.service';
import { SessionService } from "./session.service";
import { EncryptService } from './encrypt.service';
import { IpClientService } from './ipclient.service';
import { GeneralUserService } from './api/general-user.service';
import { catchError, map, Observable, tap, throwError } from 'rxjs';

@Injectable({
    providedIn: 'root',
})
export class AuthService {
    ip: string = '';

    constructor(
        private sessionService: SessionService,
        private api: GeneralUserService,
        private encrypt: EncryptService,
        private address: IpClientService,
        private router: RouterService
    ) { }

    public Login(username: string, password: string): Observable<any> {
        const credentials = `${username}|${password}`;
        const payload: Request = {
            UsuaUsuario: this.encrypt.encryptAuth(credentials),
            AudiHost: this.ip,
        };
        return this.api.connectBackend("ValidarUsuario", payload).pipe(
            map(response => {
                if (response) {
                    return response;
                }
                return null;
            }),
            tap(response => {
                if (response && response.Usuario) {
                    if (response.Usuario.UsuaCambiarContrasenia) {
                        return response.Usuario.UsuaCambiarContrasenia;
                    }
                }
            }),
            tap(response => {
                if (response && response.PersId) {
                    this.sessionService.configureTarget(response);
                    this.sessionService.setMinutosDisponibles(response.Sesion.SesiTiempo);
                    this.router.toMenu();
                }
            }),
        );
    }

    public SendMail(payload: Request): Observable<any> {
        return this.api.connectBackend("EnviarCorreo", payload).pipe(
            map(response => {
                if (response) {
                    return response;
                }
                return null;
            }),
            tap(response => {
                return response;
            }),
            catchError((error: any) => {
                return throwError(() => error);
            })
        )
    }

    public ChangePassword(username: string, password: string): Observable<any> {
        const credential = `${username}|${password}`;
        const payload: Request = {
            UsuaUsuario: this.encrypt.encryptAuth(credential),
            AudiHost: ""
        }
        return this.api.connectBackend("CambiarContrasena", payload).pipe(
            map(response => {
                if (response) {
                    return response;
                }
                return null;
            }),
            catchError((error: any) => {
                return throwError(() => error);
            })
        )
    }
}
