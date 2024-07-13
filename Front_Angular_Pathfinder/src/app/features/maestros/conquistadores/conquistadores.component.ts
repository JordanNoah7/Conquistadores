import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { NotificationService, ContextService } from 'src/app/core/services';
import { RepositoryService } from 'src/app/core/services/repository.service';
import { ConquistadorService } from 'src/app/core/services/services';

@Component({
    selector: 'ns-ss',
    templateUrl: './conquistadores.component.html',
    styleUrls: ['./conquistadores.component.css'],
})
export class ConquistadoresComponent implements OnInit {
    public isSearching: boolean = false;
    public isLoading: boolean = false;
    public tableId: string = 'tableId';

    public searchForm: FormGroup = new FormGroup({
        ConqDni: new FormControl('', []),
        ConqNombres: new FormControl('', []),
        ConqApellidos: new FormControl('', []),
        ConqEdad: new FormControl('', []),
    });

    options: any = {
        pageLength: 25,
        paging: false,
        ajax: (data: any, callback: any, settings: any) => {
            this.conquistadorService.ListadoConquistadores$.subscribe((res: any) => {
                callback({ aaData: res })
            });
        },
        searching: false,
        buttons: [
            {
                extend: 'excel',
                filename: 'Listado de almacenes',
                text: '<i class="fa fa-file-excel-o"></i>Exportar búsqueda a Excel',
                className: "btn btn-default custombutton",
                exportOptions: { columns: [1, 2, 3, 4] },
            },
        ],
        columnDefs: [],
        columns: [
            {
                title: 'Editar',
                data: 'ConqId',
                render: function (data: any, type: any, row: any, meta: any) {
                    return '<button title="Editar" class="editar btn btn-default txt-color-yellow btn-circle"><i class="fa fa-edit"></i></button>';
                },
            },
            { title: 'Nombres', data: 'ConqNombres' },
            { title: 'Apellido Paterno', data: 'ConqApellidoPaterno' },
            { title: 'Apellido Materno', data: 'ConqApellidoMaterno' },
            { title: 'Edad', data: 'ConqEdad' },
            { title: 'Celular | Teléfono', data: 'ConqMovil', },
            { title: 'Correos', data: 'ConqCorreos', },
        ],
        drawCallback: function (settings: any) {
            (<any>$('button')).tooltip();
        },
        rowCallback: (row: any, data: any, index: any) => {
            // $(row)
            //     .off()
            //     .on('click', 'button.editar', () =>
            //         this.showMView(data.ALMA_Codigo, 'Editar')
            //     );
        },
    };

    constructor(
        private contextService: ContextService,
        private notificationService: NotificationService,
        private repositoryService: RepositoryService,
        private conquistadorService: ConquistadorService
    ) { }

    ngOnInit() {
        this.Buscar();
    }

    async Buscar() {
        await this.repositoryService.GetConquistadores({}).subscribe(
            data => {
                this.conquistadorService.ListadoConquistadores$.next(data);
            },
            error => {
                console.log(error);
                this.notificationService.showSmallMessage('Error al cargar el dashboard: ' + error, false);
            }
        );
    }
}
