export const VALIDATION_OPTIONS = {
  errorElement: 'em',
  errorClass: 'invalid',
  highlight: function (element: any, errorClass: JQuery.TypeOrArray<string> | ((this: any, index: number, currentClassName: string) => string), validClass: JQuery.TypeOrArray<string> | ((this: any, index: number, className: string) => string) | undefined) {
    $(element).addClass(errorClass).removeClass(validClass);
    $(element).parent().addClass('state-error').removeClass('state-success');

  },
  unhighlight: function (element: any, errorClass: JQuery.TypeOrArray<string> | ((this: any, index: number, className: string) => string) | undefined, validClass: JQuery.TypeOrArray<string> | ((this: any, index: number, currentClassName: string) => string)) {
    $(element).removeClass(errorClass).addClass(validClass);
    $(element).parent().removeClass('state-error').addClass('state-success');
  },
  errorPlacement: function (error: { insertAfter: (arg0: any) => void; }, element: { parent: () => any; }) {
    error.insertAfter(element.parent());
  }
}
