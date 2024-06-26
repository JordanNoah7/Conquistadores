import {
  Directive,
  ElementRef,
  OnInit,
  AfterViewInit
} from '@angular/core';

import {
  LayoutService
} from "../../../core/services/layout.service";
import {
  Router,
  NavigationEnd
} from "@angular/router";
import {
  Subscription
} from 'rxjs';

@Directive({
  selector: '[saSmartMenu]'
})
export class SmartMenuDirective implements OnInit, AfterViewInit {

  private $menu: any;
  private layoutSub: Subscription = new Subscription();
  private routerSub: Subscription = new Subscription();

  constructor(
    private menu: ElementRef,
    private router: Router,
    public layoutService: LayoutService
  ) {
    this.$menu = $(this.menu.nativeElement);
  }

  ngOnInit() {
    this.layoutSub = this.layoutService.subscribe((store: any) => {
      this.processLayout(store)
    });

    // collapse menu on mobiles
    $('[routerLink]', this.$menu).on('click', () => {
      if (this.layoutService.store.mobileViewActivated) {
        this.layoutService.onCollapseMenu()
      }
    })

  }

  ngAfterViewInit() {
    this.$menu.find('li:has(> ul)').each((i: any, li: any) => {
      let $menuItem = $(li);
      let $a = $menuItem.find('>a');
      let sign = $('<b class="collapse-sign"><em class="fa fa-plus-square-o"/></b>');

      $a.on('click', (e) => {
        this.toggle($menuItem);
        e.stopPropagation();
        return false;
      }).append(sign);
    })

    setTimeout(()=>{
      this.processLayout(this.layoutService.store)
    }, 200)


  }

  ngOnDestroy() {
    this.layoutSub.unsubscribe();
  }

  private processLayout = (layoutStore: any) => {
    if (layoutStore.menuOnTop) {
      this.$menu.find('li.open').each((i: any, li: any) => {
        this.toggle($(li), false)
      })
    } else {
      this.$menu.find('li.active').each((i: any, li: any) => {
        $(li).parents('li').each((j, parentLi) => {
          this.toggle($(parentLi), true)
        })
      })
    }

    if (layoutStore.mobileViewActivated) {
      $('body').removeClass("minified");
    }
  };

  private toggle($el: any, condition = !$el.data('open')) {
    $el.toggleClass('open', condition);

    if (condition) {
      $el.find('>ul').slideDown();
    } else {
      $el.find('>ul').slideUp();
    }

    $el.find('>a>.collapse-sign>em')
      .toggleClass('fa-plus-square-o', !condition)
      .toggleClass('fa-minus-square-o', condition);

    $el.data('open', condition);

    if (condition) {
      $el.siblings('.open').each((i: any, it: any) => {
        let sib = $(it);
        this.toggle(sib, false)
      })
    }
  }

}
