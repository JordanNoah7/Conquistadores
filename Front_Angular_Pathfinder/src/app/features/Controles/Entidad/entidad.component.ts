import {
  Component,
  ElementRef,
  EventEmitter,
  Input,
  OnInit,
  Output,
  ViewChild,
} from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { BehaviorSubject } from 'rxjs';
import { RequestService, SessionService } from 'src/app/core/services';
import { ModalEntidadComponent } from '../Modales/Entidad/modalEntidad.component';

@Component({
  selector: 'ns-entidad',
  templateUrl: './entidad.component.html',
  styleUrls: ['./entidad.component.css'],
})
export class ControlEntidadComponent implements OnInit {
  $document: any;

  @Output() AreasSelected: EventEmitter<string> = new EventEmitter();
  @Output() EntidadSelected: EventEmitter<string> = new EventEmitter();
  @Input() Areas: any = [];
  @Input() AreaSelected: string = '';
  @Input() EntidadSelect: any = null;

  bsModalRef!: BsModalRef;
  //@ViewChild('inputAyuda') inputAyuda!: ElementRef;
  //@ViewChild('btnAyuda') btnAyuda!: ElementRef;
  @ViewChild('inputAyudaDesc') inputAyudaDesc!: ElementRef;
  @ViewChild('btnAyudaDesc') btnAyudaDesc!: ElementRef;

  myForm: FormGroup = new FormGroup({
    areaSelect: new FormControl(''),
  });

  constructor(
    private modalService: BsModalService,
    private sessionService: SessionService,
    private requestService: RequestService
  ) {}

  ngOnInit(): void {
    this.setValueSelect();
    this.setValueEntidad();
  }

  setValueSelect() {
    this.myForm.controls['areaSelect'].setValue(this.AreaSelected);
  }

  async setValueEntidad() {
    if (this.EntidadSelect) {
      await this.ObtenerUnItem(this.EntidadSelect);
    }
  }

  Item: any;
  Items = new BehaviorSubject<any[]>([]);
  public loading = false;

  public async MostrarModal(x_Tipo: Number, x_Filtro: any) {
    this.loading = true;
    if (this.loading !== true) {
      return;
    }

    if (!!this.Item) {
      this.cleanItem();
    } else {
      await this.ObtenerItems(x_Tipo, String(x_Filtro.value));

      if (this.Items.value.length == 1) {
        this.setItem(this.Items.value[0]);
      } else {
        const initialState: ModalOptions = {
          class: 'modal-lg',
          initialState: {
            Items: this.Items,
          },
        };

        this.bsModalRef = this.modalService.show(
          ModalEntidadComponent,
          initialState
        );

        this.modalService.onHide.subscribe(() => {
          if (!!this.bsModalRef.content.Item) {
            this.setItem(this.bsModalRef.content.Item);
          }
          this.modalService.onHide.observers = [];
          this.loading = false;
        });
      }
    }
  }

  async ObtenerItems(x_Tipo: Number, x_Filtro: String) {
    const session = this.sessionService.getCurrentSession();
    //let filtro = this.inputAyuda?.nativeElement.value;

    let _itemRequest = {
      SESS_Token: session.token.SESS_Token,
      USER_IdUser: session.token.USER_IdUser,
      USER_CodUsr: session.token.USER_CodUsr,
      AUDI_Host: session.token.AUDI_Host,
      APLI_CodApli: session.token.APLI_CodApli,
      KeyCNX: session.params.CadenaConexion,
      EMPR_CodReferencia: session.params.EMPR_CodReferencia,
      Sucursal: session.token.Sucursal,
    };

    const request = {
      itemRequest: _itemRequest,
      x_Tipo: x_Tipo,
      x_Filtro: x_Filtro,
      x_TipoEntidad: '03',
    };

    const result = await this.requestService.SendRequestOperaciones(
      request,
      'ObtenerEntidades'
    );

    if (result && (<any>result).Codigo == 0) {
      this.Items.next((<any>result).ItemsEntidad);
    }
    this.loading = false;
  }

  async ObtenerUnItem(ENTC_Codigo: string) {
    const session = this.sessionService.getCurrentSession();

    let _itemRequest = {
      SESS_Token: session.token.SESS_Token,
      USER_IdUser: session.token.USER_IdUser,
      USER_CodUsr: session.token.USER_CodUsr,
      AUDI_Host: session.token.AUDI_Host,
      APLI_CodApli: session.token.APLI_CodApli,
      KeyCNX: session.params.CadenaConexion,
      EMPR_CodReferencia: session.params.EMPR_CodReferencia,
      Sucursal: session.token.Sucursal,
    };

    const request = {
      itemRequest: _itemRequest,
      x_ENTC_Codigo: ENTC_Codigo,
      x_TipoEntidad: '03',
    };

    const result = await this.requestService.SendRequestOperaciones(
      request,
      'ObtenerEntidad'
    );

    if (result && (<any>result).Codigo == 0) {
      this.setItem((<any>result).ItemEntidad);
    }
    this.loading = false;
  }

  setItem(Item: any) {
    this.Item = Item;
    this.changeEntidad(Item.ENTC_Codigo);
    // this.inputAyuda.nativeElement.value = String(this.Item.ENTC_Ruc).trim();
    this.inputAyudaDesc.nativeElement.value = String(
      this.Item.ENTC_RazonSoc
    ).trim();

    // this.inputAyuda.nativeElement.setAttribute('readonly', 'readonly');
    this.inputAyudaDesc.nativeElement.setAttribute('readonly', 'readonly');

    // this.btnAyuda.nativeElement.setAttribute(
    //   'class',
    //   'btnAyudaSearched icon-append fa fa-times'
    // );
    this.loading = false;
    this.btnAyudaDesc.nativeElement.setAttribute(
      'class',
      'btnAyudaSearched icon-append fa fa-times'
    );
  }
  cleanItem() {
    this.Item = null;
    // this.inputAyuda.nativeElement.value = '';
    this.inputAyudaDesc.nativeElement.value = '';

    // this.inputAyuda.nativeElement.removeAttribute('readonly');
    this.inputAyudaDesc.nativeElement.removeAttribute('readonly');

    // this.btnAyuda.nativeElement.setAttribute(
    //   'class',
    //   'btnAyuda icon-append fa fa-search'
    // );
    this.loading = false;
    this.btnAyudaDesc.nativeElement.setAttribute(
      'class',
      'btnAyuda icon-append fa fa-search'
    );
  }

  changeAreas(value: any) {
    this.AreasSelected.emit(value);
  }

  changeEntidad(value: any) {
    this.EntidadSelected.emit(value);
  }
}
