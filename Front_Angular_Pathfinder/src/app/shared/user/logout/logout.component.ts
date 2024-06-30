import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { SessionService } from "src/app/core/services/session.service";
import { NotificationService } from "../../../core/services/notification.service";

@Component({
  selector: "sa-logout",
  template: `
<div id="logout" (click)="showPopup()" class="btn-header transparent pull-right">
        <span> <a title="Cerrar sesión" style="color: #202427 !important"><i class="fa fa-sign-out"></i></a> </span>
    </div>
  `,
  styles: []
})
export class LogoutComponent implements OnInit {

  public user: any;

  constructor(
    private sessionService: SessionService,
    private router: Router,
    private notificationService: NotificationService
  ) {
    const session = this.sessionService.getCurrentSession();
    this.user = session.user.USER_Nombre;
  }

  showPopup() {
    this.notificationService.smartMessageBox(
      {
        title:
          "<i class='fa fa-sign-out txt-color-orangeDark'></i><span class='txt-color-orangeDark'><strong>" + this.user +"</strong></span>, ¿Desea cerrar sesión?",
        content:
          "Para mayor seguridad le recomendamos cerrar el navegador después de cerrar la sesión",
        buttons: "[No][Si]"
      },
      ButtonPressed => {
        if (ButtonPressed == "Si") {
          this.logout();
        }
      }
    );
  }

  logout() {
    this.sessionService.logout();
  }

  ngOnInit() {}
}
