import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginRoutingModule } from './login-routing.module';
import { LoginComponent } from './login.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';
import { RECAPTCHA_V3_SITE_KEY, RecaptchaV3Module } from 'ng-recaptcha';
import { SmartadminValidationModule } from 'src/app/shared/forms/validation/smartadmin-validation.module';

import { environment } from 'src/environments/environment';

@NgModule({
  imports: [
    CommonModule,
    LoginRoutingModule,
    SharedModule,
    SmartadminValidationModule,
    ReactiveFormsModule,
    RecaptchaV3Module
  ],
  declarations: [LoginComponent],
  providers: [{ provide: RECAPTCHA_V3_SITE_KEY, useValue:  environment.appsettings.captcha.public }]
})
export class LoginModule { }
