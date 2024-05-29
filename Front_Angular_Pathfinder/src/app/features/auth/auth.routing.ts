import { Routes, RouterModule } from "@angular/router";
import { AuthGuard } from "src/app/core/guards/auth.guard";

export const routes:Routes = [
  { path: "", redirectTo: "login", pathMatch: "full" },
  {
    //path: 'login',
    path: 'login',
    loadChildren: () => import('./login/login.module').then(m => m.LoginModule)
  },
  {
    path: 'forgot',
    loadChildren: () => import('./forgot/forgot.module').then(m => m.ForgotModule)
  },
  { path: '**', redirectTo: 'login' },
  /*{
    path: 'change',
    loadChildren: () => import('./change/change.module').then(m => m.ChangeModule)
  },
  {
    path: 'recovery',
    loadChildren: () => import('./recovery/recovery.module').then(m => m.RecoveryModule)
  }*/
];

export const routing = RouterModule.forChild(routes);
