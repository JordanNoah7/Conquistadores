import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ControlEntidadComponent } from './entidad.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';
import { SmartadminValidationModule } from 'src/app/shared/forms/validation/smartadmin-validation.module';
import { SmartadminDatatableModule } from 'src/app/shared/ui/datatable/smartadmin-datatable.module';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    SmartadminValidationModule,
    ReactiveFormsModule,
    SmartadminDatatableModule
  ],
  declarations: [ControlEntidadComponent],
  exports: [ControlEntidadComponent]
})
export class ControlEntidadModule { }