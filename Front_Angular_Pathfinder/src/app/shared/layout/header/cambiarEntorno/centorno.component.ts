import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SessionService } from 'src/app/core/services';
@Component({
   selector: 'sa-centorno',
   templateUrl: './centorno.component.html'
})
export class CEntornoComponent {
   constructor(private router: Router,) {

   }
   onToggle() {
      this.router.navigate(['/enviroment',]);
   }
}
