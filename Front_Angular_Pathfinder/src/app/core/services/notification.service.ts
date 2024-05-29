import {Injectable} from '@angular/core';

declare var $: any;

@Injectable()
export class NotificationService {

  constructor() { }

  smallBox(data: { title: string; content: string; color: string; timeout: number; icon: string; sound_file?: string; }, cb?: undefined) {
    (<any>$).smallBox(data, cb)
  }  

  bigBox(data: any, cb?: any) {
    $.bigBox(data, cb)
  }

  smartMessageBox(data: { title: string; content: string; buttons: string; }, cb?: (ButtonPressed: string) => void) {
    $.SmartMessageBox(data, cb)
  }

  showSmallMessage(message: string, success: boolean) {
    this.smallBox({
      title: "Sistema",
      content: `<i class='fa fa-clock-o'></i> <i>${message}</i>`,
      color: success ? "#22bb33" : "#bb2124",
      icon: "fa fa-comment-o bounce animated",
      timeout: 4000
    });
  }

  showInformationMessage(message: string) {
    this.smallBox({
      title: "Sistema",
      content: `<i class='fa fa-clock-o'></i> <i>${message}</i>`,
      color: "#333333",
      icon: "fa fa-comment-o bounce animated",
      timeout: 4000
    });
  }
}
