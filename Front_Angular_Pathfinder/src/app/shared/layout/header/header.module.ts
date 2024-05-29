import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { NgModule } from "@angular/core";


import { CollapseMenuComponent } from "./collapse-menu/collapse-menu.component";
import { RecentProjectsComponent } from "./recent-projects/recent-projects.component";
import { FullScreenComponent } from "./full-screen/full-screen.component";
import { ManualComponent } from "./manual";

import { ActivitiesComponent } from "./activities/activities.component";
import { ActivitiesMessageComponent } from "./activities/activities-message/activities-message.component";
import { ActivitiesNotificationComponent } from "./activities/activities-notification/activities-notification.component";
import { ActivitiesTaskComponent } from "./activities/activities-task/activities-task.component";
import { HeaderComponent } from "./header.component";

import { UtilsModule } from "../../../shared/utils/utils.module";
import { PipesModule } from "../../../shared/pipes/pipes.module";
import { I18nModule } from "../../../shared/i18n/i18n.module";
import { UserModule } from "../../../shared/user/user.module";
import { BsDropdownModule } from "ngx-bootstrap/dropdown";
import { PopoverModule } from "ngx-bootstrap/popover";
import { CEntornoComponent } from "./cambiarEntorno";

@NgModule({
   imports: [
      CommonModule,
      FormsModule,
      BsDropdownModule,

      UtilsModule, PipesModule, I18nModule, UserModule, PopoverModule,
   ],
   declarations: [
      ActivitiesMessageComponent,
      ActivitiesNotificationComponent,
      ActivitiesTaskComponent,
      RecentProjectsComponent,
      ManualComponent,
      FullScreenComponent,
      CollapseMenuComponent,
      ActivitiesComponent,
      HeaderComponent,
      CEntornoComponent,
   ],
   exports: [
      HeaderComponent
   ]
})
export class HeaderModule { }
