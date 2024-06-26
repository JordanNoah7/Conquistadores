import {Directive, OnInit, ElementRef, Input} from '@angular/core';

@Directive({
  selector: '[saJquiTabs]'
})
export class JquiTabs implements OnInit {

  @Input() saJquiTabs: any;

  constructor(private el: ElementRef) {
  }

  ngOnInit() {
    $('ul a', this.el.nativeElement).each((idx, el)=> {
      let href = $(el).attr("href"),
        newHref = window.location.protocol + "//" + window.location.hostname
          + (window.location.port ? ":" + window.location.port : "") +
          window.location.pathname + href;

      if ((<any>href).indexOf("#") == 0) {
        $(el).attr("href", newHref);
      }
    });
    (<any>$(this.el.nativeElement)).tabs(this.saJquiTabs || {})

  }

}
