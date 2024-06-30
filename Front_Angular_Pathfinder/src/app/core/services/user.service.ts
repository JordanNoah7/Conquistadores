import { Injectable } from '@angular/core';
import { GeneralUserService } from './api';
import { NotificationService } from './notification.service';
import { RouterService } from './router.service';
import { SessionService } from './session.service';
import { Request, RequestRest } from '../models';
import { EncryptService } from "./encrypt.service";
import { IpClientService } from "./ipclient.service";

@Injectable()
export class UserService {
    private url: string = '';
    private manual: string = '';

    constructor(
        private notifyService: NotificationService,
        private routerService: RouterService,
        private sessionService: SessionService,
        private api: GeneralUserService,
        private encrypt: EncryptService,
        private address: IpClientService
    ) {
    }

    public async signIn(username: any, password: any) {
        const credentials = `${username}|${password}`;
        let success = false;

        let payload = new Request();
        payload.UsuaUsuario = this.encrypt.encryptAuth(credentials);
        payload.AudiHost = await this.address.GetIp();

        let response = await this.api.CallService(payload, 'ValidarUsuario');
        if (response && response.Usuario) {
            if (response.Usuario.UsuaCambiarContrasenia) {
                return response.Usuario.UsuaCambiarContrasenia;
            }
        }
        if (response && (response.ConqId || response.TutoId)) {
            success = true;
            this.sessionService.configureTarget(response);
            this.sessionService.setMinutosDisponibles(response.Sesion.SesiTiempo);
            this.routerService.toRoot();
        }
        if (!success)
            this.notifyService.showSmallMessage(response.error, success);
    }

    public async RecoverPassword(username: string) {
        const payload = new Request();
        payload.UsuaUsuario = this.encrypt.encryptAuth(username);
        let success = false;
        let message = null;
        this.notifyService.smartMessageBox(
            {
                title:
                    "<i class='fa fa-sign-out txt-color-orangeDark'></i> Recuperar <span class='txt-color-orangeDark'><strong> Contraseña </strong></span> ?",
                content: 'Esta seguro que desea generar una nueva contraseña?',
                buttons: "[No][Si]"
            },
            async ButtonPressed => {
                if (ButtonPressed == "Si") {
                    const response = await this.api.SendMail(payload);
                    if (response.Mensaje) {
                        this.notifyService.showSmallMessage(response.Mensaje, true);
                    } else {
                        this.notifyService.showSmallMessage(response.error, true);
                    }
                    this.routerService.toLogin();
                }
            }
        );

        return success;
    }

    public async ChangePassword(username: string, password: string) {
        const credentials = `${username}|${password}`;
        let payload = new Request();
        payload.UsuaUsuario = this.encrypt.encryptAuth(credentials);
        payload.AudiHost = await this.address.GetIp();
        let response = await this.api.ChangePassword(payload);
        return response;
    }
}
