import { Directive, Input, ElementRef } from "@angular/core";

@Directive({
  selector: "[saUiValidate]"
})
export class UiValidateDirective {
  @Input() saUiValidate: any;

  constructor(private el: ElementRef) {
    /*Promise.all([
      import("jquery-validation/dist/jquery.validate.js"),
      import("jquery-validation/dist/additional-methods.js")
    ])
    .then(() => {
      this.attach();
    });*/
  }

  attach() {
    const $form = $(this.el.nativeElement);
    const validateCommonOptions: any = {
      rules: {},
      messages: {},
      errorElement: "em",
      errorClass: "invalid",
      highlight: (element: any, errorClass: any, validClass: any) => {
        $(element)
          .addClass(errorClass)
          .removeClass(validClass);
        $(element)
          .parent()
          .addClass("state-error")
          .removeClass("state-success");
      },
      unhighlight: (element: any, errorClass: any, validClass: any) => {
        $(element)
          .removeClass(errorClass)
          .addClass(validClass);
        $(element)
          .parent()
          .removeClass("state-error")
          .addClass("state-success");
      },

      errorPlacement: (error: any, element: any) => {
        if (element.parent(".input-group").length) {
          error.insertAfter(element.parent());
        } else {
          error.insertAfter(element);
        }
      }
    };

    $form
      .find("[data-smart-validate-input], [smart-validate-input]")
      .each(function() {
        var $input = $(this),
          fieldName = $input.attr("name");

        validateCommonOptions.rules['fieldName'] = {};

        if ($input.data("required") != undefined) {
          validateCommonOptions.rules['fieldName'].required = true;
        }
        if ($input.data("email") != undefined) {
          validateCommonOptions.rules['fieldName'].email = true;
        }

        if ($input.data("maxlength") != undefined) {
          validateCommonOptions.rules['fieldName'].maxlength = $input.data(
            "maxlength"
          );
        }

        if ($input.data("minlength") != undefined) {
          validateCommonOptions.rules['fieldName'].minlength = $input.data(
            "minlength"
          );
        }

        if ($input.data("message")) {
          validateCommonOptions.messages['fieldName'] = $input.data("message");
        } else {
          Object.keys($input.data()).forEach(key => {
            if (key.search(/message/) == 0) {
              if (!validateCommonOptions.messages['fieldName'])
                validateCommonOptions.messages['fieldName'] = {};

              var messageKey = key.toLowerCase().replace(/^message/, "");
              validateCommonOptions.messages['fieldName'][
                messageKey
              ] = $input.data(key);
            }
          });
        }
      });

    (<any>$form).validate($.extend(validateCommonOptions, this.saUiValidate));
  }
}
