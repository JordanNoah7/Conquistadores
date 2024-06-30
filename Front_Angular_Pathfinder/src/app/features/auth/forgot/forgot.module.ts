import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ForgotRoutingModule } from './forgot-routing.module';
import { ForgotComponent } from './forgot.component';
import { ReactiveFormsModule } from '@angular/forms';
import { SmartadminValidationModule } from 'src/app/shared/forms/validation/smartadmin-validation.module';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    ForgotRoutingModule,
    SmartadminValidationModule
  ],
  declarations: [ForgotComponent]
})
export class ForgotModule { }
