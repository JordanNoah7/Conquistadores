import {Component, AfterContentInit, ElementRef, Input} from '@angular/core';

import {presets} from './chart-js.presets'

declare var Chart:any;

@Component({

  selector: 'sa-chart-js',
  template: `
  <div>
  <canvas></canvas>
  </div>
  `,
  styles: []
})
export class ChartJsComponent implements AfterContentInit {

  @Input() public data: any;
  @Input() public type: string = '';
  @Input() width:string = '100%';

  _presets: any = presets;

  constructor(private el:ElementRef) {
  }

  ngAfterContentInit() {
    import('chart.js').then((chartJs:any)=> {
      this.render()
    })
  }

  render(){
    let ctx = this.getCtx();
    let data = this.data;

    if(data.datasets && data.datasets.length && this._presets[this.type] && this._presets[this.type].dataset){
      data.datasets =  data.datasets.map((it: any)=>{
        return Object.assign({}, this._presets[this.type].dataset, it)
      })
    }

    let chart = new Chart(ctx, {
      type: this.type,
      data: data,
      options: this._presets[this.type] ? this._presets[this.type].options : {}
    });
    chart.update();

  }

  private getCtx() {
    return this.el.nativeElement.querySelector('canvas').getContext('2d');
  }

  randomScalingFactor() {
    return Math.round(Math.random() * 100);
  };
  randomColorFactor() {
    return Math.round(Math.random() * 255);
  };
  randomColor(opacity: any) {
    return 'rgba(' + this.randomColorFactor() + ',' + this.randomColorFactor() + ',' + this.randomColorFactor() + ',' + (opacity || '.3') + ')';
  };

}
