import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { NotificationService } from './notification.service';
import { RequestService } from './request.service';
import { SessionService } from './session.service';
import { resolve } from 'dns';
import { AxisDateTimeLabelFormatsOptions } from 'highcharts';

@Injectable()
export class ContextService {
  private localStorageService: any;

  private sucursales = new BehaviorSubject<any[]>([]);
  public sucursales$ = this.sucursales.asObservable();

  private almacenes = new BehaviorSubject<any[]>([]);
  public almacenes$ = this.almacenes.asObservable();

  private usuario = new BehaviorSubject<any[]>([]);
  public usuario$ = this.usuario.asObservable();

  constructor(
    private sessionService: SessionService,
    private requestService: RequestService
  ) {
    this.localStorageService = localStorage;
    this.recoverDataSession();
  }

  public async recoverDataSession() {
    const result = this.sessionService.recoverData();
    const session = this.sessionService.getCurrentSession();
    this.almacenes.next(result.Almacenes);
    this.usuario.next(result.Usuario);
  }
  getRequest(): any {
    const session = this.sessionService.getCurrentSession();
    return {
      SESS_Token: session.token.SESS_Token,
      USER_IdUser: session.token.USER_IdUser,
      USER_CodUsr: session.token.USER_CodUsr,
      AUDI_Host: session.token.AUDI_Host,
      APLI_CodApli: session.token.APLI_CodApli,
      ALMA_Codigo: session.token.Almacen,
      ALMA_Nombre: session.enviroment.Almacen.ALMA_Nombre,
      UALM_Administrador: session.token.Administrador,
      UALM_SoloLectura: session.token.SoloLectura,
      //KeyCNX: session.params.CadenaConexion,
      //EMPR_CodReferencia: session.params.EMPR_CodReferencia,
      //Sucursal: session.token.Sucursal,
    };
  }

  async ObtenerUsuarios(Proceso: string) {
    const Resquest = this.getRequest();
    const result = await this.requestService.SendRequest(
      { itemRequest: Resquest, Proceso },
      'GetUsuarios'
    );

    let resultReturn: any = [];
    if (result && (<any>result).Codigo == 0) {
      resultReturn = (<any>result).ItemsUsuarios;
    }
    return resultReturn;
  }

  async ObtenerParametros() {
    const session = this.sessionService.getCurrentSession();
    const Sucursal: string = session.enviroment.Sucursal.SUCR_Codigo;
    const Resquest = this.getRequest();

    const result = await this.requestService.SendRequestOperaciones(
      {
        itemRequest: Resquest,
        x_SUCR_Codigo: Sucursal,
        x_PARA_Aplicacion: 'GIV',
      },
      'ObtenerParametros'
    );

    let resultReturn: any = [];
    if (result && (<any>result).Codigo == 0) {
      resultReturn = (<any>result).ItemsParametro;
    }
    return resultReturn;
  }

  async GuardarParametros(ListParametros: any[]) {
    const session = this.sessionService.getCurrentSession();
    const Sucursal: string = session.enviroment.Sucursal.SUCR_Codigo;
    const Resquest = this.getRequest();

    const result = await this.requestService.SendRequestOperaciones(
      { itemRequest: Resquest, x_ListParametros: ListParametros },
      'GuardarParametros'
    );

    let resultReturn: any = [];
    if (result && (<any>result).Codigo == 0) {
      resultReturn = <any>result;
    }
    return resultReturn;
  }
}
