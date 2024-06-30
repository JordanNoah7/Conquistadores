import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { NotificationService } from './notification.service';
import { RequestService } from './request.service';
import { SessionService } from './session.service';
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
            UsuaId: session.user.UsuaId,
            UsuaUsuario: session.user.UsuaUsuario,
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
