import { Routes, RouterModule } from '@angular/router';
import {ErrorComponent} from "./error.component";
import {ModuleWithProviders} from "@angular/core";

export const errorRoutes: Routes = [
    {
        path: '',
        component: ErrorComponent,
        data: {
            pageTitle: 'Error'
        }
    }
];

export const errorRouting:ModuleWithProviders<any> = RouterModule.forChild(errorRoutes);

