import { Component, OnInit, ViewChild } from '@angular/core';
import { BsModalRef, ModalDirective } from 'ngx-bootstrap/modal';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'ns-modalCentroCosto',
  templateUrl: './modalCentroCosto.component.html',
  styleUrls: ['./modalCentroCosto.component.css'],
})
export class ModalCentroCostoComponent implements OnInit {
  Mensaje: string = "";
  Item = null;
  Titulo?: string;

  Items = new BehaviorSubject<any[]>([]);
  Items$:any;
  tableId: string = 'tableIdCC';
  options: any = {
    //order: [[1, "asc"]],
    pageLength: 25,
    ajax: (data: any, callback: any, settings: any) => {
      this.Items$.subscribe((res: any) => {
        callback({ aaData: res });
      });
    },
    columns: [
      { data: 'CENT_Codigo' },
      { data: 'CENT_Desc' },
      { data: 'CENT_Ano', visible: false },
    ],
    rowCallback: (row:any, data:any, index:any) => {
      $(row)
        .off()
        .on("dblclick", () => this.SeleccionarItem(data));
    },
  };

  constructor(public bsModalRef: BsModalRef) { }
  ngOnInit() {
    this.Titulo = "Centros de Costo";
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
