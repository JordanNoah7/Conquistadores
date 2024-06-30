import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { RouterService } from '../services';
import { SessionService } from '../services/session.service';

@Injectable()
export class AuthGuard implements CanActivate {
    constructor(private sessionService: SessionService, private routerService: RouterService) {
    }

    canActivate(): boolean {
        const result = this.sessionService.isAuthenticated();
        if (!result) {
            this.routerService.toLogin();
        }
        return result;
    }
}
