import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SettingRoutingModule } from './setting-routing.module';
import { SettingComponent } from './setting.component';
import { ReactiveFormsModule } from '@angular/forms';
import { SmartadminValidationModule } from 'src/app/shared/forms/validation/smartadmin-validation.module';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    SettingRoutingModule,
    SmartadminValidationModule
  ],
  declarations: [SettingComponent]
})
export class SettingModule { }
