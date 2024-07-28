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
                path: 'admin',
                canActivate: [AuthGuard],
                data: {
                    title: 'Admin',
                },
                loadChildren: () =>
                    import('./admin/admin.module').then((m) => m.AdminModule),
            },
            {
                path: 'extra-pages',
                canActivate: [AuthGuard],
                data: {
                    title: 'Extra Pages',
                },
                loadChildren: () =>
                    import('./extra-pages/extra-pages.module').then(
                        (m) => m.ExtraPagesModule
                    ),
            },
            {
                path: 'multilevel',
                canActivate: [AuthGuard],
                data: {
                    title: 'Multinivel',
                },
                loadChildren: () =>
                    import('./multilevel/multilevel.module').then(
                        (m) => m.MultilevelModule
                    ),
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
