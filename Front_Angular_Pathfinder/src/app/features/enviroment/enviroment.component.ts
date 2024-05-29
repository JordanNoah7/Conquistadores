import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import {
    ContextService,
    NotificationService,
    RouterService,
    SessionService,
} from 'src/app/core/services';

@Component({
    selector: 'app-enviroment',
    templateUrl: './enviroment.component.html',
    styles: [],
})
export class EnviromentComponent implements OnInit {
    public almacenes: any = null;
    public usuario: any = null;

    public logo: any;

    public form = new FormGroup({
        _almacen: new FormControl('', []),
        _usuario: new FormControl('', []),
    });

    constructor(private contextService: ContextService, private notificationService: NotificationService
        , private sessionService: SessionService, private routerService: RouterService) {
        const session = this.sessionService.getCurrentSession();
        if (!session) {
            this.notificationService.showSmallMessage(
                'Configuración incorrecta, vuelva a iniciar sesión',
                false
            );
            this.routerService.toLogin();
        }
    }

    ngOnInit() {
        let session = this.sessionService.getCurrentSession();
        this.logo = session.company.EMPR_Logo;
        this.usuario = session.user;
        this.contextService.recoverDataSession();
        this.obtenerAlmacenes();
        this.obtenerUsuario();
    }

    async obtenerAlmacenes() {
        let _almacenSeleccionado: any = [];

        await this.contextService.almacenes$.subscribe((res: any) => {
            _almacenSeleccionado = res;
        });
        if (_almacenSeleccionado.length == 1) {
            this._almacen?.disable();
        }

        this.almacenes = _almacenSeleccionado;

        this._almacen?.setValue(this.almacenes[0].ALMA_Codigo);
    }

    obtenerUsuario() {
        this._usuario?.setValue(this.usuario.USER_CodUsr);
        this._usuario?.disable();
    }

    Ingresar() {
        const _alm = this.almacenes.find((s: any) => s.ALMA_Codigo == this._almacen?.value);
        if (_alm) {
            this.sessionService.configureAlmacen(_alm);
        } else {
            this.notificationService.showSmallMessage(
                'Selecciona un almacén para continuar',
                false
            );
            return;
        }

        const _usr = this.usuario;
        if (_usr) {
            this.sessionService.configureUsuario(_usr);
        } else {
            this.notificationService.showSmallMessage(
                'Selecciona un almacén para continuar',
                false
            );
            return;
        }

        this.routerService.toMain();
    }

    Salir() {
        this.sessionService.logout();
    }

    public get _almacen() {
        return this.form.get('_almacen');
    }
    public get _usuario() {
        return this.form.get('_usuario');
    }
}
