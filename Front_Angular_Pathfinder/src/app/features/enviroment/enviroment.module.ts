import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EnviromentRoutingModule } from './enviroment-routing.module';
import { EnviromentComponent } from './enviroment.component';
import { ReactiveFormsModule  } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    EnviromentRoutingModule,
    ReactiveFormsModule
  ],
  declarations: [EnviromentComponent]
})
export class EnviromentModule { }
