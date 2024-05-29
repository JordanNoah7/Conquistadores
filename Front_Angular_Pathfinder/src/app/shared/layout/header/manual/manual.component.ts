import {Component, OnInit} from '@angular/core';
import { SessionService } from 'src/app/core/services';
@Component({
  selector: 'sa-manual',
  templateUrl: './manual.component.html'
})
export class ManualComponent{
  private urlManual: string = "";
  constructor(private sessionService: SessionService){

  }
  onToggle(){
    this.urlManual = this.sessionService.getManual();
    window.open(this.urlManual, '_blank');
  }
}
