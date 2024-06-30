import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ConquistadoresComponent } from './conquistadores/conquistadores.component';
const routes: Routes = [
    {
        path: '',
        redirectTo: 'conquistadores',
        pathMatch: 'full'
    },
    {
        path: 'conquistadores',
        component: ConquistadoresComponent,
        data: {
            title: 'Dashboard'
        },
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class MaestrosRoutingModule { }
