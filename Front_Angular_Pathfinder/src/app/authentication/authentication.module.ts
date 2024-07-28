import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { AuthenticationRoutingModule } from "./authentication-routing.module";
import { Page500Component } from "./page500/page500.component";
import { Page404Component } from "./page404/page404.component";
import { SigninComponent } from "./signin/signin.component";
import { ForgotPasswordComponent } from "./forgot-password/forgot-password.component";
import { ReactiveFormsModule } from "@angular/forms";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";
import { MatIconModule } from "@angular/material/icon";
import { MatButtonModule } from "@angular/material/button";
import { CarouselModule } from "ngx-bootstrap/carousel";
import { RECAPTCHA_V3_SITE_KEY, RecaptchaV3Module } from "ng-recaptcha";
import { environment } from 'src/environments/environment';
import { ChangePasswordComponent } from "./signin/change-password/change-password.component";
@NgModule({
    declarations: [
        Page500Component,
        Page404Component,
        SigninComponent,
        ForgotPasswordComponent,
        ChangePasswordComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        AuthenticationRoutingModule,
        MatFormFieldModule,
        MatInputModule,
        MatIconModule,
        MatButtonModule,
        CarouselModule.forRoot(),
        RecaptchaV3Module
    ],
    providers: [{ provide: RECAPTCHA_V3_SITE_KEY, useValue: environment.appsettings.captcha.public }]
})
export class AuthenticationModule { }
