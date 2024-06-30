import {Directive, ElementRef, OnInit, Input} from '@angular/core';

(<any>$).widget("ui.dialog", $.extend({}, (<any>$).ui.dialog.prototype, {
  _title: function(title: any) {
    /*if (!this.options.title ) {
      title.html("&#160;");
    } else {
      title.html(this.options.title);
    }*/
  }
}));

@Directive({
  selector: '[saJquiDialog]'
})
export class JquiDialog implements OnInit {


  @Input() saJquiDialog: any;

  constructor(private el: ElementRef) {
  }


  ngOnInit(){

    (<any>$(this.el.nativeElement)).dialog(this.saJquiDialog)
  }
}
