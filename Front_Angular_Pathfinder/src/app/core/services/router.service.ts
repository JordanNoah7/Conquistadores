import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Location } from '@angular/common'

@Injectable()
export class RouterService {
  constructor(private router: Router, private location: Location) { }

  toBack() {
    this.location.back()
  }

  toRoot(){
    this.router.navigate(['/']);
  }

  toLogin(){
    this.router.navigate(['/auth/login']);
  }

  toLoading(){
    this.router.navigate(['/loading']);
  }

  toEnviroment(){
    this.router.navigate(['/enviroment']);
  }

  toMain(){
    this.router.navigate(['/procesos']);
  }

  toConfiguracion(){
    this.router.navigate(['/configuracion']);
  }

  toVendedor(){
    this.router.navigate(['/vendedor']);
  }

  toCotizacion(){
    this.router.navigate(['/cotizacion']);
  }

  toPedido(){
    this.router.navigate(['/pedido']);
  }

  toFinalizarPedido(){
    this.router.navigate(['/finalizarPedido']);
  }

  toCuenta(){
    this.router.navigate(['/cuentacorriente']);
  }

  toCliente(){
    this.router.navigate(['/cliente']);
  }

}
