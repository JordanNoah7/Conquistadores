import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { NgScrollbarModule } from "ngx-scrollbar";
import { BaseChartDirective as chartjsModule } from "ng2-charts";
import { NgxEchartsModule } from "ngx-echarts";
import { MatIconModule } from "@angular/material/icon";
import { MatButtonModule } from "@angular/material/button";
import { ComponentsModule } from "../shared/components/components.module";
import { DashboardRoutingModule } from "./dashboard-routing.module";
import { DashboardComponent } from "./dashboard.component";
import { NgApexchartsModule } from "ng-apexcharts";
import { MatMenuModule } from "@angular/material/menu";
import { MatTooltipModule } from "@angular/material/tooltip";
import { SharedModule } from "../shared/shared.module";

@NgModule({
    declarations: [DashboardComponent],
    imports: [
        CommonModule,
        DashboardRoutingModule,
        chartjsModule,
        NgxEchartsModule.forRoot({
            echarts: () => import("echarts"),
        }),
        NgScrollbarModule,
        MatIconModule,
        MatButtonModule,
        ComponentsModule,
        NgApexchartsModule,
        NgScrollbarModule,
        MatMenuModule,
        MatTooltipModule,
        ComponentsModule,
        SharedModule,
    ],
})
export class DashboardModule { }
