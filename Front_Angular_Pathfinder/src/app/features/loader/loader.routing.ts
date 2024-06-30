import { Routes, RouterModule } from '@angular/router';
import { LoaderComponent } from "./loader.component";
import { ModuleWithProviders } from "@angular/core";

export const loaderRoutes: Routes = [
    {
        path: '',
        component: LoaderComponent,
        data: {
            pageTitle: 'Loading'
        }
    }
];

export const loaderRouting: ModuleWithProviders<any> = RouterModule.forChild(loaderRoutes);

