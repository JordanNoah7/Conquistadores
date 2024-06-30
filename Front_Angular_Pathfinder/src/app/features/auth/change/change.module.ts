import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChangeRoutingModule } from './change-routing.module';
import { ChangeComponent } from './change.component';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  imports: [
    CommonModule,
    ChangeRoutingModule,
    SharedModule
  ],
  declarations: [ChangeComponent]
})
export class ChangeModule { }
