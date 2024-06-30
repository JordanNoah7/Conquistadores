import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";
import { SessionService } from '../../../core/services';
declare var $: any;

@Component({
    selector: 'sa-header',
    templateUrl: './header.component.html',
})
export class HeaderComponent implements OnInit {
    constructor(private router: Router, public sessionService: SessionService) {
    }

    ngOnInit() {
        let session = this.sessionService.getCurrentSession();
    }

    searchMobileActive = false;

    toggleSearchMobile() {
        this.searchMobileActive = !this.searchMobileActive;
        $('body').toggleClass('search-mobile', this.searchMobileActive);
    }

    onSubmit() {
        this.router.navigate(['/miscellaneous/search']);

    }

    goUserManual() {
        this.router.navigate(['/others/manual-users']);
    }
}
