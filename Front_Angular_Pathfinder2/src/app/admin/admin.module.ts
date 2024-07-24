import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
// import {PerfectScrollbarModule} from "ngx-perfect-scrollbar";
import { NgScrollbarModule } from "ngx-scrollbar";
import { BaseChartDirective as chartjsModule } from "ng2-charts";
import { NgxEchartsModule } from "ngx-echarts";
import { MatIconModule } from "@angular/material/icon";
import { MatButtonModule } from "@angular/material/button";
import { AdminRoutingModule } from "./admin-routing.module";
import { ComponentsModule } from "../shared/components/components.module";

@NgModule({
    declarations: [],
    imports: [
        CommonModule,
        AdminRoutingModule,
        chartjsModule,
        NgxEchartsModule.forRoot({
            echarts: () => import("echarts"),
        }),
        // PerfectScrollbarModule,
        NgScrollbarModule,
        MatIconModule,
        MatButtonModule,
        ComponentsModule,
    ],
})
export class AdminModule {
}
