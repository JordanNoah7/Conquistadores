import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RegistroComponent } from './registro/registro.component';
import { Page404Component } from '../authentication/page404/page404.component';
import { FormularioComponent } from './registro/formulario/formulario.component';
import { InscripcionComponent } from './inscripcion/inscripcion.component';

const routes: Routes = [
    {
        path: "",
        redirectTo: "registro",
        pathMatch: "full",
    },
    {
        path: "registro",
        component: RegistroComponent,
    },
    {
        path: "new",
        component: FormularioComponent
    },
    {
        path: "edit",
        component: FormularioComponent
    },
    {
        path:"inscribir",
        component: InscripcionComponent
    },
    {
        path: "**",
        component: Page404Component
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class ConquistadorRoutingModule { }
