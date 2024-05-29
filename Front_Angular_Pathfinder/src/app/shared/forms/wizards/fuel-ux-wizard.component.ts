import {
  Component,
  OnInit,
  ElementRef,
  EventEmitter,
  Output
} from "@angular/core";
import "script-loader!fuelux/js/wizard.js";

@Component({
  selector: "fuel-ux-wizard",
  template: `
    <div>
      <ng-content></ng-content>
    </div>
  `,
  styles: []
})
export class FuelUxWizardComponent implements OnInit {
  @Output() complete = new EventEmitter();

  constructor(private el: ElementRef) {}

  ngOnInit() {
    const element = $(this.el.nativeElement);
    const wizard = (<any>element).wizard();

    const $form = element.find("form");

    wizard.on("actionclicked.fu.wizard", (e: any, data: any) => {
      if ($form.data("validator")) {
        if (!(<any>$form).valid()) {
          $form.data("validator").focusInvalid();
          e.preventDefault();
        }
      }
    });

    wizard.on("finished.fu.wizard", (e: any, data: any) => {
      const formData: any = {};
      $form.serializeArray().forEach(field => {
        formData[field.name] = field.value;
      });
      this.complete.emit(formData);
    });
  }
}
