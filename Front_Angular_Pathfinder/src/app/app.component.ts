import {Component} from '@angular/core';
import {LayoutService, UserService} from './core/services';

@Component({
   selector: 'app-root',
   template: '<router-outlet></router-outlet>'
})
export class AppComponent {
   title = 'ProyectoAsistencia';

   constructor(private layoutService: LayoutService,
               private userService: UserService) {
      this.layoutService.trigger();
   }
}
