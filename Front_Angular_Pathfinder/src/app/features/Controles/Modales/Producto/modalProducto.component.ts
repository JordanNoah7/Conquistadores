import { Component, OnInit, ViewChild } from '@angular/core';
import { BsModalRef, ModalDirective } from 'ngx-bootstrap/modal';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'ns-modalProducto',
  templateUrl: './modalProducto.component.html',
  styleUrls: ['./modalProducto.component.css'],
})
export class ModalProductoComponent implements OnInit {
  Mensaje: string = "";
  Item = null;
  Titulo?: string;

  Items = new BehaviorSubject<any[]>([]);
  Items$:any;
  tableId: string = 'tableIdProducto';
  options: any = {
    //order: [[1, "asc"]],
    pageLength: 25,
    ajax: (data: any, callback: any, settings: any) => {
      this.Items$.subscribe((res: any) => {
        callback({ aaData: res });
      });
    },
    columns: [
      {
        data: 'Codigo',
        render: function (data: any, type: any, row: any, meta: any) {
          return '<a style="color:black;" >'+data+'</a>';
        },
      },
      //{ data: 'Codigo' ,},
      { data: 'Producto' },
      { data: 'Marca' },
      { data: 'Unidad' },
      { data: 'Saldo' },
      { data: 'UltimoCostoSoles' },
      { data: 'ALMA_Desc1' },
      { data: 'ALMA_Desc2' }
      // { data: "MEDI_Codigo", visible: false },
    ],
    rowCallback: (row:any, data:any, index:any) => {
      $(row)
        .off()
        .on("dblclick", () => this.SeleccionarItem(data));
    },
  };

  constructor(public bsModalRef: BsModalRef) { }
  ngOnInit() {
    this.Titulo = "Productos";
    this.Items$ = this.Items.asObservable();
  }

  public SeleccionarItem(item: any): void {
    this.Item = item;
    this.bsModalRef.hide();
  }

  public CerrarModal(): void {
    this.bsModalRef.hide();
  }
}
