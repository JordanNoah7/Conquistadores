import { Component, OnInit } from "@angular/core";
import { RepositoryService } from "../core/service/repository.service";
import { formatDate, registerLocaleData } from "@angular/common";
import Swal from "sweetalert2";
import localeEs from '@angular/common/locales/es';
import { Categoria } from "../core/models/Categoria";
import { SessionService } from "../core/service/session.service";
import { ConquistadorList } from "../core/models/ConquistadorList";
registerLocaleData(localeEs, 'es');
@Component({
    selector: "app-main",
    templateUrl: "./dashboard.component.html",
    styleUrls: ["./dashboard.component.scss"],
})
export class DashboardComponent implements OnInit {
    conquistador: any;
    birthdate: any;
    categorias: Categoria[];
    hijos: ConquistadorList[] = [];

    constructor(
        private repositoryService: RepositoryService,
        private sessionService: SessionService
    ) { }

    ngOnInit() {
        this.LoadView();
    }

    async LoadView() {
        await this.repositoryService.GetCategorias().subscribe({
            next: (value: any) => {
                this.categorias = value;
            },
        });

        await this.repositoryService.GetConquistador().subscribe({
            next: (value: any) => {
                this.conquistador = value;
                this.birthdate = formatDate(this.conquistador!.PersFechaNacimiento, 'dd MMMM yyyy', 'es');
                this.birthdate = this.birthdate.replace(/ /g, " de ");
                this.categorias.map(c => {
                    c.CateEspecialidades = this.conquistador.ConqEspecialidades.filter(ce => ce.CateId === c.CateId);
                });
            },
            error: (error: any) => {
                Swal.fire({
                    title: 'Error al cargar el dashboard',
                    text: error,
                    icon: 'error',
                    timer: 3000
                })
            }
        });

        const session = this.sessionService.getCurrentSession();
        const padre = session.menu.filter(r => r.RoleNombre === 'Apoderado')
        if (padre.length > 0) {
            await this.repositoryService.GetHijos().subscribe({
                next: (value: any) => {
                    this.hijos = value;
                },
            });
        }
    }
}
