import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { Page404Component } from './authentication/page404/page404.component';
import { AuthGuard } from './core/guard/auth.guard';
import { AuthLayoutComponent } from './layout/app-layout/auth-layout/auth-layout.component';
import { MainLayoutComponent } from './layout/app-layout/main-layout/main-layout.component';
const routes: Routes = [
    {
        path: '',
        component: MainLayoutComponent,
        data: {
            title: 'Main',
        },
        canActivate: [AuthGuard],
        children: [
            { path: '', redirectTo: '/authentication/signin', pathMatch: 'full' },
            {
                path: 'dashboard',
                canActivate: [AuthGuard],
                data: {
                    title: 'Inicio',
                },
                loadChildren: () => import('./dashboard/dashboard.module').then((m) => m.DashboardModule),
            },
            {
                path: 'conquistador',
                canActivate: [AuthGuard],
                data: {
                    title: 'Conquistador',
                },
                loadChildren: () => import('./conquistador/conquistador.module').then((m) => m.ConquistadorModule),
            },
        ],
    },
    {
        path: 'authentication',
        component: AuthLayoutComponent,
        data: {
            title: 'Authentication',
        },
        loadChildren: () =>
            import('./authentication/authentication.module').then(
                (m) => m.AuthenticationModule
            ),
    },
    {
        path: '**', component: Page404Component, data: {
            title: 'Page not found',
        },
    },
];
@NgModule({
    imports: [RouterModule.forRoot(routes, {})],
    exports: [RouterModule],
})
export class AppRoutingModule { }
