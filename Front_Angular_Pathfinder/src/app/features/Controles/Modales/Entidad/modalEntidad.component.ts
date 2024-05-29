import { Component, OnInit, ViewChild } from '@angular/core';
import { BsModalRef, ModalDirective } from 'ngx-bootstrap/modal';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'ns-modalentidad',
  templateUrl: './modalEntidad.component.html',
  styleUrls: ['./modalEntidad.component.css'],
})
export class ModalEntidadComponent implements OnInit {
  Mensaje: string = "";
  Item = null;
  Titulo?: string;

  Items = new BehaviorSubject<any[]>([]);
  Items$:any;
  tableId: string = 'tableIdEntidad';
  options: any = {
    //order: [[1, "asc"]],
    pageLength: 25,
    ajax: (data: any, callback: any, settings: any) => {
      this.Items$.subscribe((res: any) => {
        callback({ aaData: res });
      });
    },
    columns: [
      { data: 'ENTC_Ruc' },
      { data: 'ENTC_RazonSoc' },
      { data: 'ENTC_Codigo' }
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
    this.Titulo = "Entidades";
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
