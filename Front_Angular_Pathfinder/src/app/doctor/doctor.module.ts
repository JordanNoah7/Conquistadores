import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { PerfectScrollbarModule } from "ngx-perfect-scrollbar";
import { ChartsModule as chartjsModule } from "ng2-charts";
import { NgxEchartsModule } from "ngx-echarts";
import { MatIconModule } from "@angular/material/icon";
import { MatLegacyButtonModule as MatButtonModule } from "@angular/material/legacy-button";
import { MatLegacyDialogModule as MatDialogModule } from "@angular/material/legacy-dialog";
import { NgApexchartsModule } from "ng-apexcharts";
import { MatLegacyPaginatorModule as MatPaginatorModule } from "@angular/material/legacy-paginator";
import { MatLegacySnackBarModule as MatSnackBarModule } from "@angular/material/legacy-snack-bar";
import { MatLegacyFormFieldModule as MatFormFieldModule } from "@angular/material/legacy-form-field";
import { MatSortModule } from "@angular/material/sort";
import { MatLegacyTabsModule as MatTabsModule } from "@angular/material/legacy-tabs";
import { MatLegacyMenuModule as MatMenuModule } from "@angular/material/legacy-menu";
import { MatDatepickerModule } from "@angular/material/datepicker";
import { MatLegacyTableModule as MatTableModule } from "@angular/material/legacy-table";
import { MatLegacySelectModule as MatSelectModule } from "@angular/material/legacy-select";
import { MatLegacyCheckboxModule as MatCheckboxModule } from "@angular/material/legacy-checkbox";
import { MatLegacyInputModule as MatInputModule } from "@angular/material/legacy-input";
import { MatLegacyTooltipModule as MatTooltipModule } from "@angular/material/legacy-tooltip";
import { MatLegacyRadioModule as MatRadioModule } from "@angular/material/legacy-radio";
import { DragDropModule } from "@angular/cdk/drag-drop";

import { DoctorRoutingModule } from "./doctor-routing.module";
import { DashboardComponent } from "./dashboard/dashboard.component";
import { ComponentsModule } from "../shared/components/components.module";

@NgModule({
  declarations: [DashboardComponent],
  imports: [
    CommonModule,
    DoctorRoutingModule,
    chartjsModule,
    NgxEchartsModule.forRoot({
      echarts: () => import("echarts"),
    }),
    PerfectScrollbarModule,
    MatIconModule,
    MatButtonModule,
    MatDialogModule,
    NgApexchartsModule,
    MatPaginatorModule,
    MatSnackBarModule,
    MatFormFieldModule,
    MatSortModule,
    MatTabsModule,
    MatMenuModule,
    MatDatepickerModule,
    MatTableModule,
    MatSelectModule,
    MatCheckboxModule,
    MatInputModule,
    MatTooltipModule,
    MatRadioModule,
    DragDropModule,
    ComponentsModule,
  ],
})
export class DoctorModule {}
