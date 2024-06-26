import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './core/guards/auth.guard';
import { AuthLayoutComponent } from './shared/layout/app-layouts/auth-layout.component';
import { MainLayoutComponent } from './shared/layout/app-layouts/main-layout.component';

const routes: Routes = [
    {
        path: '',
        component: MainLayoutComponent,
        canActivate: [AuthGuard],
        children: [
            {
                path: '',
                loadChildren: () => import('src/app/features/dashboard/dashboard.module').then((m) => m.DashboardModule)
            },
            {
                path: 'maestros',
                loadChildren: () => import('src/app/features/maestros/maestros.module').then((m) => m.MaestrosModule)
            }
        ],
    },
    {
        path: 'auth',
        component: AuthLayoutComponent,
        loadChildren: () => import('src/app/features/auth/auth.module').then((m) => m.AuthModule),
    },
    {
        path: 'loading',
        loadChildren: () => import('src/app/features/loader/loader.module').then((m) => m.LoaderModule),
    },
    {
        path: 'error',
        loadChildren: () => import('src/app/features/error/error.module').then((m) => m.ErrorModule),
    },
    { path: '**', redirectTo: 'auth' },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
})
export class AppRoutingModule {
}
