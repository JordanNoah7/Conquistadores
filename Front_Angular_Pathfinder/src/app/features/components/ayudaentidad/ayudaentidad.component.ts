import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Entidad, RequestRestGIV } from 'src/app/core/models/GestionInventarioModels/GestionInventarioModels';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
   selector: 'ns-ayudaentidad',
   templateUrl: './ayudaentidad.component.html',
   styleUrls: ['./ayudaentidad.component.css']
})
export class AyudaEntidadComponent implements OnInit {

   @Input() request: RequestRestGIV | undefined;
   @Input() Titulo: string = 'Ayuda';
   @Output() entidadSelected: EventEmitter<Entidad> = new EventEmitter<Entidad>();

   constructor(public activeModal: NgbActiveModal) { }
   ngOnInit(): void {
   }

   //constructor(public bsModalRef: BsModalRef, private repositoryService: RepositoryService) { }

   // ngOnInit(): void {
   //   this.isSearching = false;
   //   this.ObtenerCentrosCosto();
   // }

   // public entidad: Entidad | null = new Entidad();
   // private entidades = new BehaviorSubject<any[]>([]);
   // private entidades$ = this.entidades.asObservable();
   // public isSearching: boolean = false;

   // options: any = {

   // };

   // async ObtenerCentrosCosto() {
   //   this.isSearching = true;

   //   const response = await this.repositoryService.GetResponsables(this.request!);


   //   this.isSearching = false;
   // }

   // cerrarModal(entidad: Entidad | null) {
   //   if (entidad != null) {
   //     this.entidad = entidad;
   //   }
   //   else {
   //     this.entidad = null;
   //   }

   //   this.entidadSelected.emit(this.entidad!);
   //   this.bsModalRef.hide();
   // }
}
