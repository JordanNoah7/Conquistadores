import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BlankComponent } from './blank/blank.component';
const routes: Routes = [
  {
    path: 'blank',
    component: BlankComponent,
    data: {
      title: 'Blank'
    },
  },
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ExtraPagesRoutingModule {}
