import { Request } from '../models/Request';
import { Injectable } from '@angular/core';
import { RouterService } from './router.service';
import { SessionService } from "./session.service";
import { EncryptService } from './encrypt.service';
import { IpClientService } from './ipclient.service';
import { GeneralUserService } from './api/general-user.service';
import { map, Observable, tap } from 'rxjs';

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

    public async GetIp() {
        this.ip = await this.address.GetIp();
    }

    public Login(username: string, password: string, captcha: any): Observable<any> {
        this.GetIp();
        const credentials = `${username}|${password}`;
        debugger;
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
}