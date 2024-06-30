import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { NotificationService, ContextService } from 'src/app/core/services';
import { EMPTY, of } from 'rxjs';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { switchMap } from 'rxjs/operators';
// import { RepositoryService, AlmacenesService, } from 'src/app/core/services/GestionInventario/GestionInventarioServices';
// import { ApiResponse, RequestRestGIV, Almacen, Estado, } from 'src/app/core/models/GestionInventarioModels/GestionInventarioModels';

@Component({
    selector: 'ns-ss',
    templateUrl: './conquistadores.component.html',
    styleUrls: ['./conquistadores.component.css'],
})
export class ConquistadoresComponent implements OnInit {
    public isSearching: boolean = false;
    public isSaving: boolean = false;
    public isLoading: boolean = true;
    public searchForm: FormGroup = this.createAlmacenForm(false);
    public almacenForm: FormGroup = this.createAlmacenForm(true);

    // public almacenes: Almacen[] = [];
    // public estados: Estado[] = [];

    Title: string = '';
    @ViewChild('MView') public MView: ModalDirective | undefined;

    public tableId: string = 'tableId';
    options: any = {
        pageLength: 25,
        paging: false,

        ajax: (data: any, callback: any, settings: any) => {
            // this.almacenesService.ListadoAlmacenes$.subscribe((res: any) => {
            //     callback({ aaData: res });
            // });
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
        //order: [[1, 'asc']],
        columnDefs: [],
        columns: [
            {
                title: 'Editar',
                data: 'ALMA_Codigo',
                render: function (data: any, type: any, row: any, meta: any) {
                    return '<button title="Editar" class="editar btn btn-default txt-color-yellow btn-circle"><i class="fa fa-edit"></i></button>';
                },
            },
            { title: 'Nombre', data: 'ALMA_Nombre' },
            { title: 'Descripción', data: 'ALMA_Descripcion' },
            { title: 'Almacén padre', data: 'ALMA_NomPadre' },
            {
                title: 'Estado',
                data: 'ALMA_Estado',
                render: function (data: any) {
                    if (data) {
                        return '<input type="checkbox" checked disabled>';
                    } else {
                        return '<input type="checkbox" disabled>';
                    }
                },
            },
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
        // private repositoryService: RepositoryService,
        // private almacenesService: AlmacenesService
        private contextService: ContextService,
        private notificationService: NotificationService,
    ) { }

    ngOnInit() {
        // this.LoadLView();
    }

    createAlmacenForm(Mview: boolean) {
        if (Mview) {
            return new FormGroup({
                ALMA_Codigo: new FormControl('', []),
                ALMA_CodPadre: new FormControl('', []),
                ALMA_Nombre: new FormControl('', [
                    Validators.required,
                    Validators.maxLength(100),
                ]),
                ALMA_Descripcion: new FormControl('', [
                    Validators.required,
                    Validators.maxLength(100),
                ]),
                ALMA_Estado: new FormControl(true, [Validators.required]),
            });
        } else {
            return new FormGroup({
                ALMA_Nombre: new FormControl('', [Validators.maxLength(100)]),
                ALMA_CodPadre: new FormControl('', []),
                ALMA_EstadoTxt: new FormControl('', []),
            });
        }
    }
}
