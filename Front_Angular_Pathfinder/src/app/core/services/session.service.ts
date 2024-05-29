import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Md5 } from 'ts-md5/dist/md5';
import RijndaelBlock from 'rijndael-js';

const TIMER_TAG: string = '9Dl0KQrqjXEJUDLLnalvs3IHSx4D1o';
const DATES_TAG: string = '1W4lzCkyDp6ITgYv6C74RhZQrG6s2h';
const TOKEN_TAG: string = 'QrHIySHG2C0Ty1CV1rESoNYl6Csf3m';
const SESSION_TAG: string = 'TfHgygHJ2C0TKLdCj1rESoGYlhCsv64d';
const EMPRESA_TAG: string = 'SR20ygHJ2C0TKLdCj1rESoGYlhCsv65d';

@Injectable()
export class SessionService {
   private localStorageService;
   private currentSession: any = null;
   private currentEmpresa: any = null;
   private url: string = '';
   private manual: string = '';
   private persistentDate: any = null;

   private minutos_disponibles = 0;
   private default_minutos = 30;
   private time_remaing = 0;
   private date_catch: Date | null = null;
   private contador: any = null;
   private contadorMin: any = null;
   private key: any = null;
   private iv: any = null;

   private inputKey: string | null = null;
   private inputCode: string | null = null;
   private existKeys: boolean = true;
   private contadorRequest: number = 0;

   public Logo: any = null;
   private temporalData: any = null;

   constructor(
      private router: Router,
      private route: ActivatedRoute,
      private http: HttpClient
   ) {
      this.localStorageService = localStorage;
      this.route.queryParams.subscribe((res) => {
         this.contadorRequest++;
         if (this.contadorRequest > 1) {
            this.inputKey = res.key;
            this.inputCode = res.cod;
            if (this.inputKey && this.inputCode && !this.existKeys) {
               this.validarToken();
            } else if (this.existKeys) {
               this.router.navigate(['/enviroment']);
            } else {
               this.router.navigate(['/auth/login']);
            }
         }
      });
      this.generateKeys();
      this.currentSession = this.loadSessionData();
      this.getMinutosDisponibles();
   }

   private async validarToken() {
      const payload = {
         KeyToken: (<any>this.inputKey).replace(/\s+/g, '+'),
         APLI_CodApli: this.inputCode,
      };

      const result = await this.ValidarPorToken(payload);
   }

   getDefaultOptions = (): HttpHeaders => {
      const headers = new HttpHeaders();
      headers.set('Accept', 'application/json');
      headers.set('Content-Type', 'application/json');
      return headers;
   };

   public ValidarPorToken = (payload: any) =>
      new Promise<any>((resolve) =>
         this.http
            .post<any>('/auth/ValidarPorToken', payload, {
               headers: this.getDefaultOptions(),
            })
            .subscribe(
               (data) => resolve(data),
               (err) => resolve(null)
            )
      );

   //#region [ COUNTER ]

   startCounter() {
      this.contador = setTimeout(() => { this.logout(); }, this.time_remaing);
      this.contadorMin = setInterval(() => { this.changeTimes(); }, 60000);
   }

   renovateCounter() {
      this.endCounter();
      this.startCounter();
   }

   endCounter() {
      clearTimeout(this.contador);
      clearTimeout(this.contadorMin);
   }

   endSession() {
      this.endCounter();
      this.localStorageService.clear();
      this.minutos_disponibles = 0;
      this.time_remaing = 0;
      this.date_catch = null;
      this.contador = null;
      this.contadorMin = null;
   }

   changeTimes() {
      this.minutos_disponibles--;
      this.localStorageService.setItem(
         TIMER_TAG,
         this.encryptData(JSON.stringify(this.minutos_disponibles))
      );

      if (this.date_catch) {
         const date_saved = new Date(this.date_catch);
         const date_now = new Date();
         const time_elapsed = (date_now.getTime() - date_saved.getTime()) / 60000;
         if (time_elapsed > this.default_minutos) {
            this.logout();
            return;
         }
      }
   }

   setMinutosDisponibles(minutos: number) {
      if (!minutos || minutos == null || minutos == 0) {
         return;
      }
      this.generateKeys();
      this.minutos_disponibles = minutos;
      this.default_minutos = minutos;
      this.date_catch = new Date();
      this.time_remaing = this.minutos_disponibles * 60 * 1000;
      this.localStorageService.setItem(TIMER_TAG, this.encryptData(JSON.stringify(minutos)));
      this.localStorageService.setItem(DATES_TAG, this.encryptData(JSON.stringify(this.date_catch)));
      this.renovateCounter();
   }

   private getMinutosDisponibles() {
      if ((!this.key || this.key == '') && (!this.iv || this.iv == '')) {
         return;
      }

      const min_disp = this.decryptData(
         this.localStorageService.getItem(TIMER_TAG)
      );
      this.minutos_disponibles = parseFloat(min_disp) ? parseFloat(min_disp) : 0;
      this.minutos_disponibles =
         this.minutos_disponibles < 0 ? 0 : this.minutos_disponibles;
      const tim_rem = this.decryptData(
         this.localStorageService.getItem(DATES_TAG)
      );
      this.date_catch = new Date(tim_rem) ? new Date(tim_rem) : new Date();
      this.time_remaing = this.minutos_disponibles * 60 * 1000;
      if (this.time_remaing <= 0) {
         return;
      }
      this.startCounter();
   }

   /*
    private encryptData(data: any): string{
       let cipher = new RijndaelBlock(this.key, 'cbc');
       let ciphertext = cipher.encrypt(data, (256).toString(), this.iv);
       let result = btoa(ciphertext.toString())
       return result;
    }

    private decryptData(data: any){
       if (!data || data == ''){
          return '';
       }
       let text_encrypt = atob(data);
       let text_encrypted = Buffer.from(text_encrypt, 'utf8');//data.split(',').map(Number);
       let decypher = new RijndaelBlock(this.key, 'cbc');
       let plaintext = decypher.decrypt(text_encrypted, (256).toString(), this.iv);
       let original_text = String.fromCharCode.apply(null, plaintext);
       return original_text;
    }*/

   public encryptData(data: string): any {
      let cipher = new RijndaelBlock(this.key, 'cbc');
      let ciphertext = cipher.encrypt(data, '256', this.iv);
      ciphertext.toString('base64');
      return ciphertext;
   }

   private decryptData(data: any) {
      if (!data || data == '') {
         return '';
      }
      let text_encrypted = data.split(',').map(Number);
      let decypher = new RijndaelBlock(this.key, 'cbc');
      let plaintext = decypher.decrypt(text_encrypted, '256', this.iv);
      //let original_text = String.fromCharCode.apply(null, plaintext);
      return plaintext.toString();
   }

   public generateKeys() {
      this.existKeys = true;
      if (!((!this.key || this.key == '') && (!this.iv || this.iv == ''))) {
         return;
      }

      const session = this.currentSession;
      const keys = this.localStorageService.getItem(TOKEN_TAG);
      if (session) {
         const token = session.token.SESS_Token;
         const intoken = token.split('').reverse().join('');
         const md5 = new Md5();
         this.key = md5.appendStr(token).end();
         this.iv = md5.appendStr(intoken).end();
         const _keys = btoa(this.key + '$' + this.iv);
         this.localStorageService.setItem(TOKEN_TAG, _keys);
      } else if (keys) {
         const _keys = atob(keys);
         let unkeys = _keys.split('$');
         this.key = unkeys[0];
         this.iv = unkeys[1];
      } else {
         this.endSession();
         this.removeCurrentSession();
         this.existKeys = false;
      }
   }
   //#endregion

   //#region
   setcurrentEmpresa(empresa: any): void {
      this.currentEmpresa = empresa;
      this.localStorageService.setItem(EMPRESA_TAG, JSON.stringify(empresa));
   }

   getcurrentEmpresa(): any {
      return this.currentEmpresa;
   }

   //#endregion

   setRUC(url: any): void {
      this.url = url;
   }

   getRUC(): any {
      return this.url;
   }

   setManual(manual: any): void {
      this.manual = manual;
   }

   getManual(): any {
      return this.manual;
   }

   public setCurrentSession(session: any): void {
      this.currentSession = session;
      this.generateKeys();
      this.localStorageService.setItem(
         SESSION_TAG,
         this.encryptData(JSON.stringify(session))
      );
   }

   loadSessionData(): any {
      if ((!this.key || this.key == '') && (!this.iv || this.iv == '')) {
         return;
      }

      let sessionStr: string = this.decryptData(
         this.localStorageService.getItem(SESSION_TAG)
      );
      let ArrayNumbers = sessionStr.split(',').map(Number);
      let text = String.fromCharCode(...ArrayNumbers);
      text = text.slice(0, text.lastIndexOf('}') + 1);

      return text ? JSON.parse(text) : null;
   }

   getCurrentSession(): any {
      return this.currentSession;
   }

   removeCurrentSession(): boolean {
      this.localStorageService.removeItem(SESSION_TAG);
      this.currentSession = null;
      return (
         !this.localStorageService.getItem(SESSION_TAG) && !this.currentSession
      );
   }

   isAuthenticated(): boolean {
      return this.getCurrentToken() != null ? true : false;
   }

   getCurrentToken(): string {
      var session = this.getCurrentSession();
      return session && session.token ? session.token : null;
   }

   getCurrentContext(): any {
      var session = this.getCurrentSession();
      return session && session.context ? session.context : null;
   }

   setCurrentContext(context: any): void {
      this.currentSession.context = context;
      this.setCurrentSession(this.currentSession);
   }

   removeCurrentContext(): void {
      this.setCurrentContext(null);
   }

   logout(): void {
      const session = this.getCurrentSession();
      this.endSession();
      this.removeCurrentSession();
      this.router.navigate(['/auth/login']);
      //this.router.navigate(['/']);
   }

   public recoverData() {
      const session = this.getCurrentSession();
      const recovered = {
         Sucursales: session.ItemsSucursales,
         Almacenes: session.ItemAlmacenes,
         Usuario: session.Usuario,
         PuntosVenta: session.ItemsPuntoVenta,
         Vendedores: session.ItemsVendedores,
      };
      return recovered;
   }

   public configureTargetEmpresa(data: any, code: any) {
      const empresa = Object.freeze({
         Icono: data.Icono,
         Logo: data.Logo,
         background: data.background,
         CadenaConexion: data.CadenaConexion,
         EMPR_CodReferencia: data.EMPR_CodReferencia,
         code: code,
      });

      this.setcurrentEmpresa(empresa);
   }

   public configureTarget(data: any) {
      const company = data.Usuario.ItemsEmpresas[0];
      const session = Object.freeze({
         token: {
            SESS_Token: data.SESS_Token,
            USER_IdUser: data.Usuario.USER_IdUser,
            USER_CodUsr: data.Usuario.USER_CodUsr,
            AUDI_Host: "ServiciosWeb",
            ENTC_Codigo: data.Usuario.ENTC_Codigo,
            ENTC_RazonSocResponsable: data.Usuario.ENTC_RazonSocResponsable,
            APLI_CodApli: 'GIV'
            //EMPR_RUC: company.EMPR_RUC
         },
         enviroment: {
            Almacen: null,
            Usuario: null
         },
         ItemAlmacenes: data.ItemAlmacenes,
         // params: {
         //   //EMPR_MesesConsultaPorDefecto: company.EMPR_MesesConsultaPorDefecto,
         //   NIVE_CodNivel: data.Usuario.NIVE_CodNivel,
         //   gcMonedaDefault: data.Parametros.gcMonedaDefault,
         //   gcFamiliaRepuestos: data.Parametros.gcFamiliaRepuestos,
         //   gcFamiliaInsumos: data.Parametros.gcFamiliaInsumos,
         //   gcFamiliaServExternos: data.Parametros.gcFamiliaServExternos,
         //   gdTamanoOrden: data.Parametros.gdTamanoOrden,
         //   gdTamanoEquipo: data.Parametros.gdTamanoEquipo,
         //   TipoCambio: data.Parametros.TipoCambio,
         //   PorcImp1: data.Impuestos.PorcImp1,
         //   PorcImp2: data.Impuestos.PorcImp2,
         //   PorcImp3: data.Impuestos.PorcImp3,
         //   PorcImp4: data.Impuestos.PorcImp4,
         //   //USER_Perfil: data.Usuario.USER_Perfil,
         //   //USER_Proceso: data.Usuario.USER_Proceso,
         //   //EMPR_RUC: company.EMPR_RUC
         // },
         menu: (() => {
            return data.Usuario.ItemsPlantillaMenu;
         })(),
         user: {
            //TRAB_Nombres: data.Usuario.TRAB_Nombres,
            //TRAB_Apellidos: data.Usuario.TRAB_Apellidos,
            //TARJ_Codigo: data.Usuario.TARJ_Codigo,
            USER_Nombre: data.Usuario.USER_Nombre,
            USER_IdUser: data.Usuario.USER_IdUser,
            USER_CodUsr: data.Usuario.USER_CodUsr,
            TRAB_NroDocIden: data.Usuario.USER_CodUsr
         },
         company: {
            EMPR_Desc: company.EMPR_Desc,
            EMPR_RUC: company.EMPR_RUC,
            EMPR_Logo: company.EMPR_Logo,
            EMPR_Icono: company.EMPR_Icono
         },
         ItemsEmpresas: data.Usuario.ItemsEmpresas,
         PassForce: data.PassForce
      });
      this.setCurrentSession(session);
   }

   public configureSucursal(data: any) {
      const session = this.getCurrentSession();
      session.enviroment.Sucursal = data;
      session.token.Sucursal = data.SUCR_Codigo;
      this.setCurrentSession(session);
   }

   public configureAlmacen(data: any) {
      const session = this.getCurrentSession();
      session.enviroment.Almacen = data;
      session.token.Almacen = data.ALMA_Codigo;
      session.token.Administrador = data.UALM_Administrador;
      session.token.SoloLectura = data.UALM_SoloLectura;
      this.setCurrentSession(session);
   }

   public configureUsuario(data: any) {
      const session = this.getCurrentSession();
      session.enviroment.Usuario = data;
      session.token.Usuario = data.USER_CodUsr;
      this.setCurrentSession(session);
   }

   public configurePuntoVenta(data: any) {
      const session = this.getCurrentSession();
      session.enviroment.PuntoVenta = data;
      this.setCurrentSession(session);
   }

   public configureEmpresa(data: any) {
      const session = this.getCurrentSession();
      session.enviroment.Empresa = data;
      this.setCurrentSession(session);
   }

   public configureMoneda(data: any) {
      const session = this.getCurrentSession();
      session.enviroment.Moneda = data;
      this.setCurrentSession(session);
   }
}
