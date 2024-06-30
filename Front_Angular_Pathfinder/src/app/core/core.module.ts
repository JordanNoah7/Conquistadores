import {NgModule, APP_INITIALIZER, Optional, SkipSelf} from '@angular/core';
import {CommonModule} from "@angular/common";
import {HttpClientModule, HTTP_INTERCEPTORS} from "@angular/common/http";
import {AuthGuard} from "./guards/auth.guard";

import {services} from '../core/services';
import {throwIfAlreadyLoaded} from './guards/module-import.guard';

@NgModule({
   imports: [
      CommonModule,
      HttpClientModule
   ],
   exports: [],
   providers: [
      AuthGuard,
      ...services
   ]
})
export class CoreModule {
   constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
      throwIfAlreadyLoaded(parentModule, 'CoreModule');
   }
}
