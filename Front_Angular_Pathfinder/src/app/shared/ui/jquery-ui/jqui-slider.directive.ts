import {Directive, OnInit, ElementRef, Input} from '@angular/core';

@Directive({
  selector: '[saJquiSlider]'
})
export class JquiSlider implements OnInit {

  @Input() saJquiSlider: any;

  constructor(private el: ElementRef) {
  }

  ngOnInit() {
    (<any>$(this.el.nativeElement)).slider(this.saJquiSlider || {})

  }

}
