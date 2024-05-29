import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { errorRouting } from './error.routing';
import { ReactiveFormsModule } from '@angular/forms';
import { ErrorComponent } from './error.component';
import { RECAPTCHA_V3_SITE_KEY, RecaptchaV3Module } from 'ng-recaptcha';
import { SharedModule } from '../../shared/shared.module';
import { environment } from 'src/environments/environment';
import { SmartadminValidationModule } from 'src/app/shared/forms/validation/smartadmin-validation.module';

@NgModule({
  imports: [
    CommonModule,
    errorRouting,
    ReactiveFormsModule,
    RecaptchaV3Module,
    SmartadminValidationModule,
    SharedModule,
  ],
  declarations: [ErrorComponent],
  providers: [
    {
      provide: RECAPTCHA_V3_SITE_KEY,
      useValue: environment.appsettings.captcha.public,
    },
  ],
})
export class ErrorModule {}
