import { NgModule, ModuleWithProviders } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";

import { SmartadminLayoutModule } from "./layout";

import {I18nModule} from "./i18n/i18n.module";
import { UserModule } from "./user/user.module";
import { BootstrapModule } from "../shared/bootstrap.module";

import {SmartadminWidgetsModule} from "./widgets/smartadmin-widgets.module";

import {UtilsModule} from "./utils/utils.module";
import {PipesModule} from "./pipes/pipes.module";
import {StatsModule} from "./stats/stats.module";
import {InlineGraphsModule} from "./graphs/inline/inline-graphs.module";
import {SmartadminFormsLiteModule} from "./forms/smartadmin-forms-lite.module";
import {SmartProgressbarModule} from "./ui/smart-progressbar/smart-progressbar.module";
import { CalendarComponentsModule } from "../shared/calendar/calendar-components.module";
import { LoadingComponent } from "../shared/layout/loading/loading.component";

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    SmartadminLayoutModule,
    BootstrapModule
  ],
  declarations: [LoadingComponent],
  exports: [
    CommonModule,
    FormsModule,
    RouterModule,
    UserModule,
    SmartadminLayoutModule,
    BootstrapModule,
    I18nModule,
    UtilsModule,
    PipesModule,
    SmartadminFormsLiteModule,
    SmartProgressbarModule,
    InlineGraphsModule,
    SmartadminWidgetsModule,
    StatsModule,
    CalendarComponentsModule,
    LoadingComponent,
  ]
})
export class SharedModule {}
