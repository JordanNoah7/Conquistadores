import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { PerfectScrollbarModule } from "ngx-perfect-scrollbar";
import { ChartsModule as chartjsModule } from "ng2-charts";
import { NgxEchartsModule } from "ngx-echarts";
import { MatIconModule } from "@angular/material/icon";
import { MatLegacyButtonModule as MatButtonModule } from "@angular/material/legacy-button";
import { MatLegacySnackBarModule as MatSnackBarModule } from "@angular/material/legacy-snack-bar";
import { MatLegacyFormFieldModule as MatFormFieldModule } from "@angular/material/legacy-form-field";
import { MatLegacyTabsModule as MatTabsModule } from "@angular/material/legacy-tabs";
import { NgApexchartsModule } from "ng-apexcharts";
import { MatDatepickerModule } from "@angular/material/datepicker";
import { MatLegacySelectModule as MatSelectModule } from "@angular/material/legacy-select";
import { MatLegacyCheckboxModule as MatCheckboxModule } from "@angular/material/legacy-checkbox";
import { MatLegacyInputModule as MatInputModule } from "@angular/material/legacy-input";
import { MatLegacyTooltipModule as MatTooltipModule } from "@angular/material/legacy-tooltip";
import { MatLegacyRadioModule as MatRadioModule } from "@angular/material/legacy-radio";

import { PatientRoutingModule } from "./patient-routing.module";
import { DashboardComponent } from "./dashboard/dashboard.component";
import { ComponentsModule } from "../shared/components/components.module";

@NgModule({
  declarations: [DashboardComponent],
  imports: [
    CommonModule,
    chartjsModule,
    NgxEchartsModule.forRoot({
      echarts: () => import("echarts"),
    }),
    PerfectScrollbarModule,
    MatIconModule,
    MatButtonModule,
    PatientRoutingModule,
    NgApexchartsModule,
    MatSnackBarModule,
    MatFormFieldModule,
    MatTabsModule,
    MatDatepickerModule,
    MatSelectModule,
    MatCheckboxModule,
    MatInputModule,
    MatTooltipModule,
    MatRadioModule,
    ComponentsModule,
  ],
})
export class PatientModule {}
