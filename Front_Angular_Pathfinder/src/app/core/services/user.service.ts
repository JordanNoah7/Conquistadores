import {Injectable} from '@angular/core';
import {GeneralUserService} from './api';
import {NotificationService} from './notification.service';
import {RouterService} from './router.service';
import {SessionService} from './session.service';
import {Request, RequestRest} from '../models';
import {EncryptService} from "./encrypt.service";

@Injectable()
export class UserService {
   private url: string = '';
   private manual: string = '';

   constructor(
      private notifyService: NotificationService,
      private routerService: RouterService,
      private sessionService: SessionService,
      private api: GeneralUserService,
      private encrypt: EncryptService
   ) {
   }

   public async signIn(
      username: any,
      password: any,
      tokenCaptcha: any,
      ip: any
   ) {
      const credentials = `${username}|${password}`;
      let success = false;

      let payload = new Request();
      payload.UsuaUsuario = this.encrypt.encryptAuth(credentials);
      payload.AudiHost = ip;

      let response = await this.api.CallService(payload, 'ValidarUsuario');
      console.log(response);
      debugger;
      if (response && (response.ConqId || response.TutoId)) {
         console.log('entro al if');
         success = true;
         this.sessionService.configureTarget(response);
         console.log('configuro la sesion');
         this.sessionService.setMinutosDisponibles(response.Sesion.SesiTiempo);
         console.log('configuro el tiempo');
         // this.validateEnviroment(response);
      }
      // if (!success)
      //    this.notifyService.showSmallMessage(response.Mensaje, success);
   }

   private validateEnviroment(data: any) {
      let showEnviromentScreen = false;
      //VALIDACION DE ALMACENES
      if (data && data.ItemAlmacenes && data.ItemAlmacenes.length == 1) {
         this.sessionService.configureAlmacen(data.ItemAlmacenes[0]);
         showEnviromentScreen = true;
      } else if (data && data.ItemAlmacenes && data.ItemAlmacenes.length > 1) {
         showEnviromentScreen = true;
      } else {
         this.notifyService.showSmallMessage(
            'El usuario no tiene almacenes asignados.',
            false
         );
         //this.notifyService.showSmallMessage(data.Mensaje, false);
         setTimeout(() => {
         }, 3000);
         this.sessionService.logout();
         return;
      }

      if (!!showEnviromentScreen) {
         this.routerService.toEnviroment();
      } else {
         this.routerService.toRoot();
      }
   }

   public async ObtenerCorreo(username: string) {
      const payload = {
         USER_CodUsr: this.encrypt.encryptAuth(username)
      };
      let success = false;
      let message = null;
      const {ObtenerCorreoResult} = await this.api.ObtenerCorreo(payload);
      success = !ObtenerCorreoResult.codigo;
      message = ObtenerCorreoResult.Mensaje;
      if (success) {
         this.notifyService.smartMessageBox(
            {
               title:
                  "<i class='fa fa-sign-out txt-color-orangeDark'></i> Recuperar <span class='txt-color-orangeDark'><strong> Contraseña </strong></span> ?",
               content: message,
               buttons: "[No][Si]"
            },
            ButtonPressed => {
               if (ButtonPressed == "Si") {
                  this.EnviarCorreo(ObtenerCorreoResult, payload);
               }
            }
         );
      } else {
         this.api.TokenTimeOut();
      }

      if (!success)
         this.notifyService.showSmallMessage(message, success);

      return success;
   }

   public async EnviarCorreo(response: any, request: any) {
      const payload = {
         EMPR_RUC: response.EMPR_RUC,
         USER_CodUsr: request.USER_CodUsr,
         AUDI_HostCrea: ""
      }

      let success = false;
      let message = null;
      const {EnviarCorreoResult} = await this.api.EnviarCorreo(payload);
      success = !EnviarCorreoResult.codigo;
      message = EnviarCorreoResult.Mensaje;

      if (!success)
         this.notifyService.showSmallMessage(message, success);
      else {
         this.notifyService.showSmallMessage("Solicitud de cambio de contraseña realizado correctamente. Por favor verifique su correo para obtener sus credenciales.", success);
         this.routerService.toLogin();
      }
   }
}
