import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
    {
        path: 'dashboard',
        data: {
            title: 'Admin'
        },
        loadChildren: () =>
            import('./dashboard/dashboard.module').then((m) => m.DashboardModule),
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class AdminRoutingModule {
}
