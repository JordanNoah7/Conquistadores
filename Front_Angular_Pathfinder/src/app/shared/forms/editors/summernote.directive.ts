import {
  Directive,
  ElementRef,
  Input,
  OnInit,
  Output,
  EventEmitter
} from "@angular/core";

import "summernote/dist/summernote.min.js";

@Directive({
  selector: "[summernote]"
})
export class SummernoteDirective implements OnInit {
  @Input() summernote = {};
  @Output() change = new EventEmitter();

  constructor(private el: ElementRef) {}

  ngOnInit() {
    (<any>$(this.el.nativeElement)).summernote(
      Object.assign(this.summernote, {
        tabsize: 2,
        callbacks: {
          onChange: (we: any, contents: any, $editable: any) => {
            this.change.emit(contents);
          }
        }
      })
    );
  }
}
