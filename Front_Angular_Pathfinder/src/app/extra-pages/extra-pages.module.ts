import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ExtraPagesRoutingModule } from "./extra-pages-routing.module";
import { BlankComponent } from "./blank/blank.component";
import { MatExpansionModule } from "@angular/material/expansion";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { MatLegacyFormFieldModule as MatFormFieldModule } from "@angular/material/legacy-form-field";
import { MatLegacyButtonModule as MatButtonModule } from "@angular/material/legacy-button";
import { MatIconModule } from "@angular/material/icon";
import { MatLegacyInputModule as MatInputModule } from "@angular/material/legacy-input";
import { MatLegacyCheckboxModule as MatCheckboxModule } from "@angular/material/legacy-checkbox";
import { ComponentsModule } from "../shared/components/components.module";
@NgModule({
  declarations: [BlankComponent],
  imports: [
    CommonModule,
    ExtraPagesRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    MatExpansionModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    MatButtonModule,
    MatCheckboxModule,
    ComponentsModule,
  ],
})
export class ExtraPagesModule {}
