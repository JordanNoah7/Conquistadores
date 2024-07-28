import { Router, NavigationEnd } from "@angular/router";
import { DOCUMENT } from "@angular/common";
import { Component, Inject, ElementRef, OnInit, Renderer2, HostListener, OnDestroy } from "@angular/core";
import { AuthService } from "src/app/core/service/auth.service";
import { SessionService } from "src/app/core/service/session.service";
import { ROUTES } from "./sidebar-items";
import Swal from "sweetalert2";
@Component({
    selector: "app-sidebar",
    templateUrl: "./sidebar.component.html",
    styleUrls: ["./sidebar.component.sass"],
})
export class SidebarComponent implements OnInit, OnDestroy {
    public sidebarItems: any[];
    public innerHeight: any;
    public bodyTag: any;
    listMaxHeight: string;
    listMaxWidth: string;
    userFullName: string;
    userImg: string;
    userType: string;
    headerHeight = 60;
    currentRoute: string;
    routerObj = null;

    constructor(
        @Inject(DOCUMENT) private document: Document,
        private renderer: Renderer2,
        public elementRef: ElementRef,
        private authService: AuthService,
        private sessionService: SessionService,
        private router: Router
    ) {
        const body = this.elementRef.nativeElement.closest("body");
        this.routerObj = this.router.events.subscribe((event) => {
            if (event instanceof NavigationEnd) {
                this.renderer.removeClass(this.document.body, "overlay-open");
            }
        });
    }
    @HostListener("window:resize", ["$event"])
    windowResizecall(event) {
        this.setMenuHeight();
        this.checkStatuForResize(false);
    }
    @HostListener("document:mousedown", ["$event"])
    onGlobalClick(event): void {
        if (!this.elementRef.nativeElement.contains(event.target)) {
            this.renderer.removeClass(this.document.body, "overlay-open");
        }
    }

    callToggleMenu(event: any, length: any) {
        if (length > 0) {
            const parentElement = event.target.closest("li");
            const activeClass = parentElement.classList.contains("active");
            if (activeClass) {
                this.renderer.removeClass(parentElement, "active");
            } else {
                this.renderer.addClass(parentElement, "active");
            }
        }
    }
    ngOnInit() {
        const session = this.sessionService.getCurrentSession();
        let roles = "";
        if (session) {
            this.userFullName = session.token.UsuaNombre;
            this.userImg = session.token.PersSexo == 'M' ? 'assets/images/Conquistador.png' : 'assets/images/Conquistadora.png';

            this.sidebarItems = ROUTES.filter(
                (x) => x.role.indexOf("All") !== -1
            );
            session.menu.map(r => {
                roles += r.RoleNombre + " | ";
                const items = ROUTES.filter(
                    (x) => x.role.indexOf(r.RoleNombre) !== -1
                );
                this.sidebarItems.push(...items);
            });
            this.userType = roles.substring(0, roles.length - 2);
        }
        this.initLeftSidebar();
        this.bodyTag = this.document.body;
    }
    ngOnDestroy() {
        this.routerObj.unsubscribe();
    }
    initLeftSidebar() {
        const _this = this;
        _this.setMenuHeight();
        _this.checkStatuForResize(true);
    }
    setMenuHeight() {
        this.innerHeight = window.innerHeight;
        const height = this.innerHeight - this.headerHeight;
        this.listMaxHeight = height + "";
        this.listMaxWidth = "500px";
    }
    isOpen() {
        return this.bodyTag.classList.contains("overlay-open");
    }
    checkStatuForResize(firstTime) {
        if (window.innerWidth < 1170) {
            this.renderer.addClass(this.document.body, "ls-closed");
        } else {
            this.renderer.removeClass(this.document.body, "ls-closed");
        }
    }
    mouseHover(e) {
        const body = this.elementRef.nativeElement.closest("body");
        if (body.classList.contains("submenu-closed")) {
            this.renderer.addClass(this.document.body, "side-closed-hover");
            this.renderer.removeClass(this.document.body, "submenu-closed");
        }
    }
    mouseOut(e) {
        const body = this.elementRef.nativeElement.closest("body");
        if (body.classList.contains("side-closed-hover")) {
            this.renderer.removeClass(this.document.body, "side-closed-hover");
            this.renderer.addClass(this.document.body, "submenu-closed");
        }
    }
    logout() {
        Swal.fire({
            title: this.userFullName + " ¿Desea cerrar sesión?",
            text: "Para mayor seguridad le recomendamos cerrar el navegador después de cerrada la sesión",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: "#3085d6",
            cancelButtonColor: "#d33",
            confirmButtonText: "Si",
            cancelButtonText: "No"
        }).then(async (result) => {
            if (result.isConfirmed) {
                this.sessionService.logout();
            }
        });
    }
}
