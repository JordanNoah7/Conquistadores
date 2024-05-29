import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EnviromentComponent } from "./enviroment.component";

const routes: Routes = [{
  path: '',
  component: EnviromentComponent
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: []
})
export class EnviromentRoutingModule { }
