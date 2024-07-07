import { Component, OnInit } from '@angular/core';
import { ContextService, IpClientService, NotificationService } from 'src/app/core/services';
import { Request } from 'src/app/core/models';
import { RepositoryService } from 'src/app/core/services/repository.service';
import { ConquistadorDTO } from 'src/app/core/models/ConquistadorDTO';
import { formatDate, registerLocaleData } from '@angular/common';
import localeEs from '@angular/common/locales/es';

registerLocaleData(localeEs, 'es');

@Component({
    selector: 'ns-ss',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.css'],
})
export class DashboardComponent implements OnInit {
    conquistador?: ConquistadorDTO;

    birthdate: string = '';
    savings: string = '0';
    points: string = '0';
    class: any;
    classImage: string = 'assets/img/excursionista.png';
    unit: any;
    unitImage: string = 'assets/img/halcones.png';

    constructor(
        private ipClientService: IpClientService,
        private contextService: ContextService,
        private repositoryService: RepositoryService,
        private notificationService: NotificationService,
    ) { }

    ngOnInit() {
        this.LoadView();
    }

    async LoadView() {
        let request: Request = this.contextService.getRequest();
        request.AudiHost = await this.ipClientService.GetIp();
        await this.repositoryService.GetConquistador(request).subscribe(
            data => {
                this.conquistador = data;
                this.birthdate = formatDate(this.conquistador.ConqFechaNacimiento, 'dd MMMM yyyy', 'es');
                this.birthdate = this.birthdate.replace(/ /g, " de ");
            },
            error => {
                this.notificationService.showSmallMessage('Error al cargar el dashboard: ' + error, false);
            }
        );
    }
}
