import {Injectable} from '@angular/core';
import {GeneralUserService} from './api';
import {NotificationService} from './notification.service';
import {RouterService} from './router.service';
import {SessionService} from './session.service';
import * as JsEncryptModule from 'jsencrypt';
import {RequestRest} from '../models/GestionInventarioModels/GestionInventarioModels';

@Injectable()
export class UserService {
   private url: string = '';
   private manual: string = '';
   private encrypt = new JsEncryptModule.JSEncrypt();

   constructor(
      private notifyService: NotificationService,
      private routerService: RouterService,
      private sessionService: SessionService,
      private api: GeneralUserService
   ) {
   }

   public async validateRUC(ruc: any) {
      const result = await this.api
         .CallService(
            {
               RUC: ruc,
            },
            'ValidarRUC'
         )
         .then((res: any) => {
            this.sessionService.setRUC(res.error.text);
         });
   }

   public async getEmpresa(code: any) {
      const result = await this.api
         .CallService(
            {
               Codigo: code,
            },
            'ObtenerEmpresa'
         )
         .then(async (res: any) => {
            if (res) {
               // ObtenerEmpresaResult:
               // CadenaConexion: "057FF64C3FC124C1DECA09A7FCF0835767C7E025A5B8B59CABBCF4DC2E070E39D287300011B51C75A5522A58381DEE4DF4BBD0AF1BF50E7416F5867001138540E1CC484A6D1F38EE2EEC3F35FA24E84E918EA55BE51A9A7CD0B1C8E815228E9961E974DA4219479029313EE6630751BAD8EFF7D27940839049C81AA4C64A0B77BE46D113B7ABE614C9DD1B85F35EE76218EEEDB8CF65EA15A372C370A6964B6231C37F2189019AC754DA9A5E59EB580F37D981ECAC99A1B75E7806469C18B9D3B6B2528A228FCB9497411203522F15A2F71D7A05F3B391AD282B310BFC6D1C41342EBCACF5B3F7A5D6EBA4130005AE8F596DBE94AF4B6B33E818DA58F5CE3E58B56664B3155335A8D9AF33E229FADF720978CCDF7BCDD3000808A38E015E2CD5B74733AA1BAEDC1BD660A1AC1AE01C8EB31FC420FADC7CDF5A0528F33703FFD1979039DACA3FEB9A88BFFC24D4152AB87CF327C8D83A0886A891736B6C8223B4D287300011B51C75A5522A58381DEE4DF4BBD0AF1BF50E7416F5867001138540E1CC484A6D1F38EE2EEC3F35FA24E84E918EA55BE51A9A7CD0B1C8E815228E99FB63F898C97C991C589E73631DD7EEE0D28A2A73FB72F6DAC3A16191EDA6D8B5166FBCA099B3D7FD9EC886ACDC948A9A93BDF65567E148CDAFE4FA22D94FDA3072B13D83E96B68969180CEDD749ABB3A8A5BE67C09C106CEF4462980A35F1258DFDA12C27B3E708B0737D5D3FE81A69B6A298980BA3D5BED6FFEE68839070B2305E7B505FEB6E3B7DAA5F224C67F73B48BE70ADE2862A71EC261B9D6CB130243DA668B61C9EBAF443E0C83E8FEEA1757B8E5E32EE8E938237585E677AD7DFC2E86C52C076AB52DAD81701F9CC86829A01C9363757E49F1A0A189DAD8B49188A7C8D6C91D501751E3A013995AF3E8147461C9F7E4EA3DE88A8E7E8CEC17897D4E"
               // EMPR_CodReferencia: "00011"
               // Icono: "https://service.solutions-ns.com/LogosEmpresas/IconoGeneral_32x32.png"
               // Logo: "https://service.solutions-ns.com/LogosEmpresas/Logo-TecnicaPeru_v2.png"
               // Mensaje: null
               // background: "https://service.solutions-ns.com/LogosEmpresas/Background_0001.png"
               // codigo: 0
               await this.getConfigInicial();
               this.sessionService.configureTargetEmpresa(res, code);
               this.sessionService.setManual(this.manual);
               this.getPublicKey();
            }
         });
   }

   public async getConfigInicial() {
      await this.api.CallService('', 'getConfigInicial').then((res: any) => {
         if (res) {
            this.manual = (<any> res).Manual;
         }
      });
   }

   public async getPublicKey() {
      let payload = new RequestRest();
      payload.TypeKey = 'PEM';
      this.api.CallService(payload, 'GetPublicKey')
         .then((res: any) => {
            if (res) {
               this.encrypt.setPublicKey(res.error.text);
            }
         });
   }

   // public async getConfigInitial(){
   //   const result = await this.api.CallService({}, 'getConfigInicial');
   //   this.sessionService.Logo = (result.getConfigInicialResult.Logo ? result.getConfigInicialResult.Logo : 'assets/img/logo.png');
   // }
   public async signIn(
      username: any,
      password: any,
      tokenCaptcha: any,
      ip: any
   ) {
      const credentials = `${username}|${password}`;
      let success = false;

      let payload = new RequestRest();
      payload.Key = this.encrypt.encrypt(credentials).toString();
      payload.APLI_CodApli = 'GIV';
      payload.Captcha = tokenCaptcha;
      payload.IpClient = ip;

      // const payload = {
      //   Key: this.encrypt.encrypt(credentials),
      //   APLI_CodApli: 'LOW',
      //   Captcha: tokenCaptcha,
      //   IpClient: ip,
      // };
      let response = await this.api.CallService(payload, 'ValidarUsuario');
      if (response && response.codigo && response.codigo == 99) {
         await this.api
            .CallService({TypeKey: 'PEM'}, 'GetPublicKey')
            .then((res: any) => {
               if (res) {
                  const publicKey = res.GetPublicKeyResult;
                  this.encrypt.setPublicKey(publicKey);
               }
            });
         const payload_new = {
            Key: this.encrypt.encrypt(credentials),
            APLI_CodApli: 'GIV',
         };
         response = await this.api.CallService(payload_new, 'ValidarUsuario');
      }
      if (response && response.Usuario) {
         success = true;
         this.sessionService.configureTarget(response);
         this.sessionService.setMinutosDisponibles(response.TiempoSesion);
         this.validateEnviroment(response);
      }
      if (!success) {
         this.notifyService.showSmallMessage(response.Mensaje, success);
      }
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
         USER_CodUsr: this.encrypt.encrypt(username)
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

      if (!success) {
         this.notifyService.showSmallMessage(message, success);
      }

      return success;
   }

   public async EnviarCorreo(response: any, request: any) {
      const payload = {
         EMPR_RUC: response.EMPR_RUC,
         USER_CodUsr: request.USER_CodUsr,
         AUDI_HostCrea: ""
      };

      let success = false;
      let message = null;
      const {EnviarCorreoResult} = await this.api.EnviarCorreo(payload);
      success = !EnviarCorreoResult.codigo;
      message = EnviarCorreoResult.Mensaje;

      if (!success) {
         this.notifyService.showSmallMessage(message, success);
      } else {
         this.notifyService.showSmallMessage("Solicitud de cambio de contraseña realizado correctamente. Por favor verifique su correo para obtener sus credenciales.", success);
         this.routerService.toLogin();
      }
   }
}
