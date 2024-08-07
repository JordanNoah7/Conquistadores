import { First3Component } from "./first3/first3.component";
import { First2Component } from "./first2/first2.component";
import { First1Component } from "./first1/first1.component";
import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

const routes: Routes = [
  {
    path: "first1",
    component: First1Component,
    data: {
      title: 'First1'
    },
  },
  {
    path: "first2",
    component: First2Component,
    data: {
      title: 'First2'
    },
  },
  {
    path: "first3",
    component: First3Component,
    data: {
      title: 'First3'
    },
  },
  {
    path: "secondlevel",
    loadChildren: () =>
      import("./secondlevel/secondlevel.module").then(
        (m) => m.SecondLevelModule
      ),
  },
  {
    path: "thirdlevel",
    loadChildren: () =>
      import("./thirdlevel/thirdlevel.module").then((m) => m.ThirdlevelModule),
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MultilevelRoutingModule {}
