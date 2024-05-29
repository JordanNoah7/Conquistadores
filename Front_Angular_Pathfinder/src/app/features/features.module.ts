import { NgModule } from "@angular/core";
import { SmartadminDatatableModule } from 'src/app/shared/ui/datatable/smartadmin-datatable.module';
import { SmartadminValidationModule } from 'src/app/shared/forms/validation/smartadmin-validation.module';
import { CommonModule } from "@angular/common";
import { ReactiveFormsModule } from "@angular/forms";
import { RecaptchaModule } from "ng-recaptcha";

@NgModule({
    imports: [
        SmartadminDatatableModule,
        SmartadminValidationModule,
        CommonModule,
        ReactiveFormsModule,
        RecaptchaModule
    ],
    declarations: [
    ],
    exports: [
        SmartadminDatatableModule,
        SmartadminValidationModule,
        CommonModule,
        ReactiveFormsModule,
        RecaptchaModule,
    ]
})
export class FeatureModule { }
