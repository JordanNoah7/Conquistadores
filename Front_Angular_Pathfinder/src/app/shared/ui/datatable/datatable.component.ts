import {
    Component,
    Input,
    ElementRef,
    AfterContentInit,
    OnInit,
} from '@angular/core';

import 'script-loader!./datatables.min.js';

@Component({
    selector: 'sa-datatable',
    template: `
      <table
         id="{{ tableId }}"
         class="dataTable responsive {{ tableClass }}"
         width="{{ width }}"
      >
         <ng-content></ng-content>
      </table>
   `,
    styleUrls: ['./datatables.min.css'],
})
export class DatatableComponent implements OnInit {
    @Input() public options: any;
    @Input() public filter: any;
    @Input() public detailsFormat: any;

    @Input() public paginationLength: boolean = false;
    @Input() public columnsHide: boolean = false;
    @Input() public onlyTable: boolean = false;
    @Input() public tableClass: string = '';
    @Input() public tableId: string = '';
    @Input() public width: string = '100%';

    constructor(private el: ElementRef) { }

    ngOnInit() {
        this.render();
    }

    render() {
        let element = $(this.el.nativeElement.children[0]);
        let options = this.options || {};

        let toolbar = '';
        if (options.buttons) toolbar += 'B';
        if (this.paginationLength) toolbar += 'l';
        if (this.columnsHide) toolbar += 'C';

        if (typeof options.ajax === 'string') {
            let url = options.ajax;
            options.ajax = {
                url: url,
                // complete: function (xhr) {
                //
                // }
            };
        }

        let dt_toolbar = this.onlyTable
            ? 't'
            : "<'dt-toolbar'<'col-xs-12 col-sm-6'f><'col-sm-6 col-xs-12 hidden-xs text-right'" +
            toolbar +
            '>r>' +
            't' +
            "<'dt-toolbar-footer'<'col-sm-6 col-xs-12 hidden-xs'i><'col-xs-12 col-sm-6'p>>";

        options = $.extend(options, {
            dom: dt_toolbar,
            oLanguage: {
                sSearch:
                    "<span class='input-group-addon'><i class='fa fa-search'></i></span> ",
                sLengthMenu: '_MENU_',
            },
            autoWidth: false,
            retrieve: true,
            initComplete: (settings: any, json: any) => {
                element
                    .parent()
                    .find('.input-sm')
                    .removeClass('input-sm')
                    .addClass('input-md')
                    .attr('autocomplete', 'off');
            },
        });

        options = {
            ...options,
            oLanguage: {
                sProcessing: 'Procesando...',
                sLengthMenu: '_MENU_ registros',
                sZeroRecords: 'No se encontraron resultados',
                sEmptyTable: 'No hay registros disponibles',
                sInfo: 'Registros del _START_ al _END_ de un total de _TOTAL_',
                sInfoEmpty: 'No hay registros disponibles',
                sInfoFiltered: '(filtrado de _MAX_ registros)',
                sInfoPostFix: '',
                sSearch: '<span style="margin-left: -6px;" class="input-group-addon" autocomplete="off"><i class="fa fa-search"></i></span> ',
                sUrl: '',
                sInfoThousands: ',',
                sLoadingRecords: 'Cargando...',
                oPaginate: {
                    sFirst: 'Primero',
                    sLast: 'Último',
                    sNext: 'Siguiente',
                    sPrevious: 'Anterior',
                },
                oAria: {
                    sSortAscending:
                        ': Activar para ordenar la columna de manera ascendente',
                    sSortDescending:
                        ': Activar para ordenar la columna de manera descendente',
                },
                buttons: {
                    copy: 'Copiar',
                    //colvis: 'Visibilidad'
                },
            },
        };

        const _dataTable = (<any>element).DataTable(options);
        _dataTable.on('xhr.dt', (e: any, settings: any, data: any) =>
            _dataTable.clear()
        );

        if (this.filter) {
            // Apply the filter
            element.on('keyup change', 'thead th input[type=text]', function () {
                _dataTable
                    .column($(this).parent().index() + ':visible')
                    .search(this.value)
                    .draw();
            });
        }

        if (!toolbar) {
            element
                .parent()
                .find('.dt-toolbar')
                .append('<div class="text-right"></div>');
        }

        if (this.detailsFormat) {
            let format = this.detailsFormat;
            element.on('click', 'td.details-control', function () {
                var tr = $(this).closest('tr');
                var row = _dataTable.row(tr);
                if (row.child.isShown()) {
                    row.child.hide();
                    tr.removeClass('shown');
                } else {
                    row.child(format(row.data())).show();
                    tr.addClass('shown');
                }
            });
        }
    }
}
