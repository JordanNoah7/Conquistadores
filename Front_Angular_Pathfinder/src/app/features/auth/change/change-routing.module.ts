import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {ChangeComponent} from "./change.component";

const routes: Routes = [{
  path: '',
  component: ChangeComponent
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: []
})
export class ChangeRoutingModule { }
