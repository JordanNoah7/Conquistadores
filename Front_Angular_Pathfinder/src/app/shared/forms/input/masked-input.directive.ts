import { Directive, Input, ElementRef, OnInit } from "@angular/core";

import "script-loader!jquery.maskedinput/src/jquery.maskedinput.js";

@Directive({
  selector: "[saMaskedInput]"
})
export class MaskedInput implements OnInit {
  @Input() saMaskedInput: string | undefined;
  @Input() saMaskedPlaceholder: string | undefined;

  constructor(private el: ElementRef) {}

  ngOnInit() {
    let options = this.saMaskedPlaceholder
      ? { placeholder: this.saMaskedPlaceholder }
      : "";
    (<any>$(this.el.nativeElement)).mask(this.saMaskedInput, options);
  }
}
