import {
  Component,
  OnInit,
  Input,
  Output,
  EventEmitter,
  ElementRef,
  Renderer2,
  OnChanges
} from "@angular/core";

import "script-loader!smartadmin-plugins/bower_components/jquery-nestable/jquery.nestable.js";

let counter = 1;

@Component({
  selector: "sa-nestable-list",
  template: '<div class="dd"></div>'
})
export class NestableListComponent implements OnChanges {
  @Input() items: any;
  @Input() options: any;
  @Output() change = new EventEmitter<any>();

  constructor(private el: ElementRef, private renderer: Renderer2) {}

  ngOnInit() {
    this.render();
  }

  ngOnChanges() {
    this.render();
  }

  private render() {
    if (!this.items) return;
    const root = this.el.nativeElement.getElementsByTagName("div")[0];
    root.appendChild(this.createBranch(this.items));
    let options = this.options || {};

    (<any>$(root)).nestable(options);

    $(root).on("change", () => {
      this.change.emit((<any>$(root)).nestable("serialize"));
    });
  }

  private createChild(item: any) {
    const li = document.createElement("li");

    li.className = "dd-item";
    li.dataset["id"] = item.id || "NestableListComponent" + counter++;

    if (item.content) {
      const div = document.createElement("div");
      div.className = "dd-handle";
      div.innerHTML = item.content;
      li.appendChild(div);
    }

    if (item.children) {
      const branch = this.createBranch(item.children);
      li.appendChild(branch);
    }

    return li;
  }

  private createBranch(items: any) {
    const ol = document.createElement("ol");
    ol.className = "dd-list";
    items.forEach((item: any) => {
      ol.appendChild(this.createChild(item));
    });
    return ol;
  }
}
