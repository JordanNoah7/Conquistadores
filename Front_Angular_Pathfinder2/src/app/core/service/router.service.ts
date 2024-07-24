import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Location } from '@angular/common'

@Injectable()
export class RouterService {
    constructor(private router: Router, private location: Location) { }

    toMenu(){
        this.router.navigate(['/admin/dashboard/main']);
    }

    toBack() {
        this.location.back()
    }

    toRoot() {
        this.router.navigate(['/']);
    }

    toLogin() {
        this.router.navigate(['/auth/login']);
    }

    toLoading() {
        this.router.navigate(['/loading']);
    }

    toMain() {
        this.router.navigate(['/procesos']);
    }

    toConfiguracion() {
        this.router.navigate(['/configuracion']);
    }

    redirectToError404() {

    }

    redirectToError500() {

    }
}
