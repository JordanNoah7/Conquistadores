import { Component, OnInit } from '@angular/core';
import { NotificationService, ContextService, SessionService, IpClientService } from 'src/app/core/services';
import { Request } from 'src/app/core/models';
import { RepositoryService } from 'src/app/core/services/repository.service';

@Component({
    selector: 'ns-ss',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.css'],
})
export class DashboardComponent implements OnInit {
    fullName: string = '';
    birthdate: string = '09/07/1999';
    email: string = 'jordan.quispe@nextsoft.com.pe';
    phone: string = '914786862';
    savings: string = '0';
    points: string = '0';
    class: any;
    classImage: string = 'assets/img/excursionista.png';
    unit: any;
    unitImage: string = 'assets/img/halcones.png';

    constructor(
        private ipClientService: IpClientService,
        private sessionService: SessionService,
        private contextService: ContextService,
        private notificationService: NotificationService,
        private repositoryService: RepositoryService
    ) { }

    ngOnInit() {
        let session = this.sessionService.getCurrentSession();
        this.fullName = session.token.UsuaNombre;
        this.LoadView();
    }

    async LoadView() {
        debugger;
        let request: Request = this.contextService.getRequest();
        request.AudiHost = await this.ipClientService.GetIp();
        //TODO: Mejorar la llamada al servicio con el ejemplo de LoginAdmin
        const conquistador = await this.repositoryService.GetConquistador(request);
    }
}
