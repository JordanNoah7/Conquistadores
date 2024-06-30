import { NgModule } from '@angular/core';
import { ControlEntidadModule } from './Entidad/entidad.module';
import { ModalCentroCostoModule } from './Modales/CentroCosto/modalCentroCosto.module';
import { ModalEntidadModule } from './Modales/Entidad/modalEntidad.module';
import { ModalProductoModule } from './Modales/Producto/modalProducto.module';

@NgModule({
    imports: [
        ControlEntidadModule,
        ModalEntidadModule,
        ModalCentroCostoModule,
        ModalProductoModule
    ],
    declarations: [],
    exports: [
        ControlEntidadModule,
        ModalEntidadModule,
        ModalCentroCostoModule,
        ModalProductoModule
    ]
})
export class ControlesModule {}
