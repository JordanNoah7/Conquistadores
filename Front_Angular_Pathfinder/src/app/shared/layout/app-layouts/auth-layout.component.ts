import { Component, OnInit } from '@angular/core';
import { SessionService } from 'src/app/core/services';


@Component({
  selector: 'app-auth-layout',
  templateUrl: './auth-layout.component.html',
  styles: [],
})
export class AuthLayoutComponent implements OnInit {
  public logo: any = null;

  constructor(public sessionService: SessionService ) { }

  ngOnInit() {
    setTimeout(() => {
      // let empresa= this.sessionService.getcurrentEmpresa();
      // this.logo = empresa.Logo;
    }, 2000);
  }
}
