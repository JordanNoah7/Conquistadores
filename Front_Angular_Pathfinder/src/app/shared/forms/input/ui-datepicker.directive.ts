import { Directive, ElementRef, OnInit, Input } from '@angular/core';

@Directive({
  selector: '[saUiDatepicker]',
})
export class UiDatepickerDirective implements OnInit {
  @Input() saUiDatepicker: any;

  constructor(private el: ElementRef) {}

  ngOnInit() {
    let onSelectCallbacks: any = [];
    let saUiDatepicker = this.saUiDatepicker || {};
    let element = $(this.el.nativeElement);

    if (saUiDatepicker.minRestrict) {
      onSelectCallbacks.push((selectedDate: any) => {
        (<any>$(saUiDatepicker.minRestrict)).datepicker(
          'option',
          'minDate',
          selectedDate
        );
      });
    }
    if (saUiDatepicker.maxRestrict) {
      onSelectCallbacks.push((selectedDate: any) => {
        (<any>$(saUiDatepicker.maxRestrict)).datepicker(
          'option',
          'maxDate',
          selectedDate
        );
      });
    }

    //Let others know about changes to the data field
    onSelectCallbacks.push((selectedDate: any) => {
      element.triggerHandler('change');

      let form = element.closest('form');

      if (typeof (<any>form).bootstrapValidator == 'function') {
        try {
          (<any>form).bootstrapValidator('revalidateField', element);
        } catch (e: any) {
        }
      }
    });

    let options = $.extend(saUiDatepicker, {
      prevText: '<i class="fa fa-chevron-left"></i>',
      nextText: '<i class="fa fa-chevron-right"></i>',
      onSelect: (selectedDate: any) => {
        onSelectCallbacks.forEach((callback: any) => {
          callback.call(callback, selectedDate);
        });
      },
    });

    (<any>element).datepicker(options);
  }
}
