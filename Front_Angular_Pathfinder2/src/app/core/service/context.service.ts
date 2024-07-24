import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { SessionService } from './session.service';

@Injectable()
export class ContextService {
    constructor(
        private sessionService: SessionService,
    ) {
        this.recoverDataSession();
    }

    public async recoverDataSession() {
        const session = this.sessionService.getCurrentSession();
    }
    getRequest(): any {
        const session = this.sessionService.getCurrentSession();
        return {
            UsuaId: session ? session.user.UsuaId : '',
            UsuaUsuario: session ? session.user.UsuaUsuario : '',
        };
    }
}
