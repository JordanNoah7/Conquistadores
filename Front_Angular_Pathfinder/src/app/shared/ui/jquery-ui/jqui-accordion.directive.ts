import {Directive, OnInit, ElementRef, Input} from '@angular/core';

@Directive({
  selector: '[saJquiAccordion]'
})
export class JquiAccordion implements OnInit {

  @Input() saJquiAccordion: any;
  constructor(private el: ElementRef) { }

  ngOnInit(){

    let options = Object.assign({
      autoHeight : false,
      heightStyle : "content",
      collapsible : true,
      animate : 300,
      icons: {
        header: "fa fa-plus",    // custom icon class
        activeHeader: "fa fa-minus" // custom icon class
      },
      header : "h4"
    }, (this.saJquiAccordion ||  {}));
    (<any>$(this.el.nativeElement)).accordion(options)

  }

}
