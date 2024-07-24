import { Injectable } from '@angular/core';
import { Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

import { AuthService } from '../service/auth.service';
import { ContextService } from '../service/context.service';

@Injectable({
    providedIn: 'root',
})
export class AuthGuard {
    constructor(private contextService: ContextService, private router: Router) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (this.contextService.getRequest()) {
            const userRole = this.contextService.getRequest().role;
            if (route.data.role && route.data.role.indexOf(userRole) === -1) {
                this.router.navigate(['/authentication/signin']);
                return false;
            }
            return true;
        }

        this.router.navigate(['/authentication/signin']);
        return false;
    }
}
