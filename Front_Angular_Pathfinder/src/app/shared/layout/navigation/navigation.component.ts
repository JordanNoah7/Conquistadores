import { Component, OnInit } from '@angular/core';
import { LoginInfoComponent } from '../../user/login-info/login-info.component';
import { SessionService } from 'src/app/core/services';
import { Router,NavigationEnd} from '@angular/router';

@Component({
  selector: 'sa-navigation',
  templateUrl: './navigation.component.html',
})
export class NavigationComponent implements OnInit {
  public APROB: boolean = true;
  public RUNID: boolean = true;
  public RMATE: boolean = true;
  public OCOMP: boolean = true;
  public OSERV: boolean = true;
  public SCOMP: boolean = true;
  public SSOMP: boolean = true;
  public RECHA: boolean = true;

  public REGIS: boolean = true;
  public REGRU: boolean = true;
  public REGRM: boolean = true;
  public REGSC: boolean = true;
  public REGSS: boolean = true;

  public REPOR: boolean = true;
  public RAPRO: boolean = true;
  public CONFI: boolean = true;
  public PARAM: boolean = true;

  constructor(private router: Router, private sessionService: SessionService) {}

  ngOnInit() {
    const session = this.sessionService.getCurrentSession();
    // OPCI_Estado: "A"
    // OPCI_Menu: "OCOMP"

    // let opciones: any = [];
    // opciones = session.menu;

    // let item = opciones.findIndex((obj: any) => obj.OPCI_Menu == 'APROB');
    // if (item >= 0)
    //   this.APROB = opciones[item].OPCI_Estado == 'A' ? true : false;

    // item = opciones.findIndex((obj: any) => obj.OPCI_Menu == 'RUNID');
    // if (item >= 0)
    //   this.RUNID = opciones[item].OPCI_Estado == 'A' ? true : false;

    // item = opciones.findIndex((obj: any) => obj.OPCI_Menu == 'RMATE');
    // if (item >= 0)
    //   this.RMATE = opciones[item].OPCI_Estado == 'A' ? true : false;

    // item = opciones.findIndex((obj: any) => obj.OPCI_Menu == 'SCOMP');
    // if (item >= 0)
    //   this.SCOMP = opciones[item].OPCI_Estado == 'A' ? true : false;
    // item = opciones.findIndex((obj: any) => obj.OPCI_Menu == 'SSOMP');
    // if (item >= 0)
    //   this.SSOMP = opciones[item].OPCI_Estado == 'A' ? true : false;

    // item = opciones.findIndex((obj: any) => obj.OPCI_Menu == 'OCOMP');
    // if (item >= 0)
    //   this.OCOMP = opciones[item].OPCI_Estado == 'A' ? true : false;

    // item = opciones.findIndex((obj: any) => obj.OPCI_Menu == 'OSERV');
    // if (item >= 0)
    //   this.OSERV = opciones[item].OPCI_Estado == 'A' ? true : false;

    // item = opciones.findIndex((obj: any) => obj.OPCI_Menu == 'RECHA');
    // if (item >= 0)
    //   this.RECHA = opciones[item].OPCI_Estado == 'A' ? true : false;

    // item = opciones.findIndex((obj: any) => obj.OPCI_Menu == 'REGIS');
    // if (item >= 0)
    //   this.REGIS = opciones[item].OPCI_Estado == 'A' ? true : false;
    // item = opciones.findIndex((obj: any) => obj.OPCI_Menu == 'REGRU');
    // if (item >= 0)
    //   this.REGRU = opciones[item].OPCI_Estado == 'A' ? true : false;
    // item = opciones.findIndex((obj: any) => obj.OPCI_Menu == 'REGRM');
    // if (item >= 0)
    //   this.REGRM = opciones[item].OPCI_Estado == 'A' ? true : false;
    // item = opciones.findIndex((obj: any) => obj.OPCI_Menu == 'REGSC');
    // if (item >= 0)
    //   this.REGSC = opciones[item].OPCI_Estado == 'A' ? true : false;
    // item = opciones.findIndex((obj: any) => obj.OPCI_Menu == 'REGSS');
    // if (item >= 0)
    //   this.REGSS = opciones[item].OPCI_Estado == 'A' ? true : false;



    // item = opciones.findIndex((obj: any) => obj.OPCI_Menu == 'REPOR');
    // if (item >= 0)
    //   this.REPOR = opciones[item].OPCI_Estado == 'A' ? true : false;

    // item = opciones.findIndex((obj: any) => obj.OPCI_Menu == 'RAPRO');
    // if (item >= 0)
    //   this.RAPRO = opciones[item].OPCI_Estado == 'A' ? true : false;

    //   item = opciones.findIndex((obj: any) => obj.OPCI_Menu == 'CONFI');
    //   if (item >= 0)
    //     this.CONFI = opciones[item].OPCI_Estado == 'A' ? true : false;

    //   item = opciones.findIndex((obj: any) => obj.OPCI_Menu == 'PARAM');
    //   if (item >= 0)
    //     this.PARAM = opciones[item].OPCI_Estado == 'A' ? true : false;

  }

  public currentRoute: any;


  Redireccionar(OPCION: string) {
    this.router.navigate(['documento', OPCION]);
    //window.location.reload();
  }

  isActive(ruta:any): boolean{
    this.router.events.subscribe((event:any) => {
      event instanceof NavigationEnd;
      this.currentRoute = event.url;
    });

    let activo = false;

    if (this.currentRoute == ruta) {
      activo = true;
    }

    return activo;

  }

}
