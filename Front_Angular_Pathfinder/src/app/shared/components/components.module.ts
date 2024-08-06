import { NgModule } from '@angular/core';
import { FileUploadComponent } from './file-upload/file-upload.component';
import { BreadcrumbComponent } from './breadcrumb/breadcrumb.component';
import { SharedModule } from '../shared.module';
import { ModalPdfComponent } from './modal-pdf/modal-pdf.component';
import { NgxExtendedPdfViewerModule } from 'ngx-extended-pdf-viewer';

@NgModule({
    declarations: [FileUploadComponent, BreadcrumbComponent, ModalPdfComponent],
    imports: [SharedModule, NgxExtendedPdfViewerModule],
    exports: [FileUploadComponent, BreadcrumbComponent, ModalPdfComponent],
})
export class ComponentsModule { }
