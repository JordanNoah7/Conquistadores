import { Component, OnInit } from '@angular/core';
import { SessionService } from 'src/app/core/services';
import { Router, NavigationEnd } from '@angular/router';

@Component({
    selector: 'sa-navigation',
    templateUrl: './navigation.component.html',
})
export class NavigationComponent implements OnInit {
    public currentRoute: any;

    constructor(private router: Router, private sessionService: SessionService) { }

    ngOnInit() {
        const session = this.sessionService.getCurrentSession();
    }

    Redireccionar(OPCION: string) {
        this.router.navigate(['documento', OPCION]);
    }

    isActive(ruta: any): boolean {
        this.router.events.subscribe((event: any) => {
            event instanceof NavigationEnd;
            this.currentRoute = event.url;
        });

        let activo = false;

        if (this.currentRoute == ruta) {
            activo = true;
        }

        return activo;
    }
}
