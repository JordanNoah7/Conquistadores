import { NgModule } from "@angular/core";
import { ToggleActiveDirective } from "./toggle-active.directive";

@NgModule({
  declarations: [ToggleActiveDirective,
    ],
  exports: [ToggleActiveDirective]
})
export class UtilsModule {}
