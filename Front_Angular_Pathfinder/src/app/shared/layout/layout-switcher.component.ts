import {Component, OnInit, OnDestroy} from '@angular/core';
import {config} from '../../core/smartadmin.config';
import {LayoutService} from '../../core/services/layout.service'
import { Subscription } from 'rxjs';

declare var $: any;

@Component({
  selector: 'sa-layout-switcher',
  templateUrl: './layout-switcher.component.html'
})
export class LayoutSwitcherComponent implements OnInit, OnDestroy {
  isActivated:boolean = false;
  smartSkin:string = '';
  store: any;
  private sub: Subscription = new Subscription();

  constructor(public layoutService:LayoutService) {}

  ngOnInit() {
    this.sub = this.layoutService.subscribe((store: any)=>{
      this.store = store;
    });
    this.store = this.layoutService.store;
  }

  ngOnDestroy(){
    this.sub.unsubscribe()
  }


  onToggle() {
    this.isActivated = !this.isActivated
  }


  onSmartSkin(skin: any) {
    this.layoutService.onSmartSkin(skin)
  }


  onFixedHeader() {
    this.layoutService.onFixedHeader()
  }


  onFixedNavigation() {
    this.layoutService.onFixedNavigation()
  }


  onFixedRibbon() {
    this.layoutService.onFixedRibbon()
  }


  onFixedPageFooter() {
    this.layoutService.onFixedPageFooter()
  }


  onInsideContainer() {
    this.layoutService.onInsideContainer()
  }


  onRtl() {
    this.layoutService.onRtl()
  }


  onMenuOnTop() {
    this.layoutService.onMenuOnTop()
  }


  onColorblindFriendly() {
    this.layoutService.onColorblindFriendly()
  }


  factoryReset() {
    this.layoutService.factoryReset()
  }
}
