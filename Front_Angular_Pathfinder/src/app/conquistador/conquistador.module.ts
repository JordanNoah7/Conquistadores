import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { NgScrollbarModule } from "ngx-scrollbar";
import { BaseChartDirective as chartjsModule } from "ng2-charts";
import { NgxEchartsModule } from "ngx-echarts";
import { MatIconModule } from "@angular/material/icon";
import { MatButtonModule } from "@angular/material/button";
import { ComponentsModule } from "../shared/components/components.module";
import { ConquistadorRoutingModule } from "./conquistador-routing.module";
import { MatTableModule } from "@angular/material/table";
import { MatPaginatorModule } from "@angular/material/paginator";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";
import { MatSnackBarModule } from "@angular/material/snack-bar";
import { MatDialogModule } from "@angular/material/dialog";
import { MatSortModule } from "@angular/material/sort";
import { MatToolbarModule } from "@angular/material/toolbar";
import { MatSelectModule } from "@angular/material/select";
import { MatCheckboxModule } from "@angular/material/checkbox";
import { MatDatepickerModule } from "@angular/material/datepicker";
import { MatTabsModule } from "@angular/material/tabs";
import { MatTooltipModule } from "@angular/material/tooltip";
import { MatTableExporterModule } from "mat-table-exporter";
import { MatProgressSpinnerModule } from "@angular/material/progress-spinner";
import { RegistroComponent } from "./registro/registro.component";
import { SharedModule } from "../shared/shared.module";
import { FormularioComponent } from "./registro/formulario/formulario.component";
import { TipoDialogComponent } from "./registro/formulario/tipo-dialog/tipo-dialog.component";
import { TutoresDialogComponent } from "./registro/formulario/tutores-dialog/tutores-dialog.component";
import { ClaseDialogComponent } from "./registro/formulario/clase-dialog/clase-dialog.component";
import { UnidadDialogComponent } from "./registro/formulario/unidad-dialog/unidad-dialog.component";

@NgModule({
    declarations: [
        RegistroComponent,
        FormularioComponent,
        TipoDialogComponent,
        TutoresDialogComponent,
        ClaseDialogComponent,
        UnidadDialogComponent,
    ],
    imports: [
        CommonModule,
        ConquistadorRoutingModule,
        chartjsModule,
        NgxEchartsModule.forRoot({
            echarts: () => import("echarts"),
        }),
        NgScrollbarModule,
        MatIconModule,
        MatButtonModule,
        ComponentsModule,
        MatTableModule,
        MatPaginatorModule,
        MatFormFieldModule,
        MatInputModule,
        MatSnackBarModule,
        MatDialogModule,
        MatSortModule,
        MatToolbarModule,
        MatSelectModule,
        MatCheckboxModule,
        MatDatepickerModule,
        MatTabsModule,
        MatTooltipModule,
        MatTableExporterModule,
        MatProgressSpinnerModule,
        SharedModule
    ],
})
export class ConquistadorModule { }
