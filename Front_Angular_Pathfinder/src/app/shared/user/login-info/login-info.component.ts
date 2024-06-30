import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../core/services/user.service';
import { LayoutService } from '../../../core/services/layout.service';
import { SessionService } from 'src/app/core/services/session.service';

@Component({
    selector: 'sa-login-info',
    templateUrl: './login-info.component.html',
})
export class LoginInfoComponent implements OnInit {
    public user: any;
    public userSiglas?: string;

    constructor(
        public sessionService: SessionService, private layoutService: LayoutService) {
    }

    ngOnInit() {
        this.user = this.sessionService.getCurrentSession();
        this.userSiglas = this.calcularIniciales(this.user.token.UsuaNombre);
    }

    toggleShortcut() {
        this.layoutService.onShortcutToggle();
    }

    private calcularIniciales(user: string): string {
        const nombres = user.split(' ');

        if (nombres.length >= 1) {
            let primeraLetra = nombres[0][0].toUpperCase();
            let segundaLetra = '';

            if (nombres.length > 1) {
                segundaLetra = nombres[nombres.length - 1][0].toUpperCase();
            }

            return primeraLetra + segundaLetra;
        } else {
            return '';
        }
    }
}
