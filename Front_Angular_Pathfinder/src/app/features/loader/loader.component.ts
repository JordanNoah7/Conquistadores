import { Component, OnInit } from '@angular/core';
import { RouterService } from '../../core/services';

@Component({
  selector: 'app-loader',
  templateUrl: './loader.component.html',
  styleUrls: ['./loader.component.css']
})
export class LoaderComponent implements OnInit {

  public message: string = '';
  private numMessage: number = 0;
  private timer: any = null;

  constructor(private routerService: RouterService) { }

  ngOnInit() {
    this.showMessages();
  }

  ngOnDestroy(): void {
    this.timer = null;
  }

  redirect() {
    this.routerService.toRoot();
  }

  async showMessages(){
    this.timer = setInterval(() => {
      switch (this.numMessage) {
        case 0:
          this.message = 'Iniciando aplicación...'
          break;
        case 1:
          this.message = 'Generando entorno...'
          break;
        case 2:
          this.message = 'Cargando componentes...'
          break;
        default:
          this.message = 'Espere por favor...'
          break;
      }
      this.numMessage++;
    }, 1500)
  }


}
