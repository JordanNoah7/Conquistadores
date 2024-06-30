import { NgModule, LOCALE_ID } from '@angular/core';
import { LocationStrategy, HashLocationStrategy, PathLocationStrategy, registerLocaleData, DatePipe } from '@angular/common'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BrowserModule } from '@angular/platform-browser';
import { ModalModule } from 'ngx-bootstrap/modal';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { CoreModule } from './core/core.module';
import { SharedModule } from './shared/shared.module';
import { I18nModule } from './shared/i18n/i18n.module';

import localeEsPE from '@angular/common/locales/es-PE';

import { ImageViewerModule } from 'ngx-image-viewer';

registerLocaleData(localeEsPE);

@NgModule({
    declarations: [
        AppComponent,
    ],
    imports: [
        BrowserModule,
        BrowserAnimationsModule,
        ModalModule.forRoot(),
        ImageViewerModule.forRoot(),
        AppRoutingModule,
        CoreModule,
        SharedModule,
        I18nModule,
    ],
    providers: [
        { provide: LocationStrategy, useClass: HashLocationStrategy },
        { provide: LOCALE_ID, useValue: 'es-PE' },
        DatePipe
    ],
    bootstrap: [AppComponent],
    exports: [
        AppComponent
    ]
})
export class AppModule { }
