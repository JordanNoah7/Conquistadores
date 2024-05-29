import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { loaderRouting } from './loader.routing';

import { LoaderComponent } from "./loader.component";
import { SharedModule } from '../../shared/shared.module';

@NgModule({
  imports: [
    CommonModule,
    loaderRouting,
    SharedModule
  ],
  declarations: [LoaderComponent],
  providers: [],
})
export class LoaderModule { }
