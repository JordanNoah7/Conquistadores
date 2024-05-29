import {Injectable, ApplicationRef} from '@angular/core';

import {config} from '../../core/smartadmin.config';
import {languages} from './languages.model';
import { Subject } from 'rxjs';

@Injectable()
export class I18nService {

  public state: any;
  public data: any = {};
  public currentLanguage:any;


  constructor(private ref:ApplicationRef) {
    this.state = new Subject();

    this.initLanguage(config.defaultLocale || 'es');
    this.fetch(this.currentLanguage.key)
  }

  private fetch(locale: any) {

  }

  private initLanguage(locale:string) {
    let language = languages.find((it: any)=> {
      return it.key == locale
    });
    if (language) {
      this.currentLanguage = language
    } else {
      throw new Error(`Incorrect locale used for I18nService: ${locale}`);

    }
  }

  setLanguage(language: any){
    this.currentLanguage = language;
    this.fetch(language.key)
  }


  subscribe(sub:any, err:any) {
    return this.state.subscribe(sub, err)
  }

  public getTranslation(phrase:string):string {
    return this.data && this.data[phrase] ? this.data[phrase] : phrase
  }

}
