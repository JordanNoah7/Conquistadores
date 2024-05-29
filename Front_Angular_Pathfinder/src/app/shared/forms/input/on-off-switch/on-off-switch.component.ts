import {Component, OnInit, Input, EventEmitter, Output} from '@angular/core';

@Component({
  selector: 'on-off-switch',
  templateUrl: './on-off-switch.component.html',
})
export class OnOffSwitchComponent implements OnInit {

  @Input() title:string | undefined;

  @Input() model:boolean | undefined;
  @Output() modelChange = new EventEmitter();

  @Input() value:any;

  public widgetId: string = '';

  constructor() {
  }


  ngOnInit() {
    this.value = this.model;

    this.widgetId = 'on-off-switch' + OnOffSwitchComponent.widgetsCounter++;
  }

  onChange() {
    this.modelChange.emit(this.value)
  }


  static widgetsCounter = 0
}
