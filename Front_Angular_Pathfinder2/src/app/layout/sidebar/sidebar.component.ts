import { Router, NavigationEnd } from "@angular/router";
import { DOCUMENT } from "@angular/common";
import { Component, Inject, ElementRef, OnInit, Renderer2, HostListener, OnDestroy, } from "@angular/core";
import { AuthService } from "src/app/core/service/auth.service";
import { SessionService } from "src/app/core/service/session.service";
import { MatDialog } from "@angular/material/dialog";

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
    public menuList: any[];

    public REP: boolean = false;
    public LOGIS: boolean = false;
    public SERV: boolean = false;
    public COMB: boolean = false;
    public RRHH: boolean = false;
    public NSTOCK: boolean = false;
    public DFLOTA: boolean = false;

    constructor(
        @Inject(DOCUMENT) private document: Document,
        private renderer: Renderer2,
        public elementRef: ElementRef,
        private authService: AuthService,
        private router: Router,
        private sessionService: SessionService,
        private dialogModel: MatDialog
    ) {
        const body = this.elementRef.nativeElement.closest("body");
        this.routerObj = this.router.events.subscribe((event) => {
            if (event instanceof NavigationEnd) {
                // close sidebar on mobile screen after menu select
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
        this.loadMenuClassic();

        let nomuser = this.sessionService.getCurrentSession();
        this.userFullName = nomuser.user.USER_Nombre;

        this.initLeftSidebar();
        this.bodyTag = this.document.body;
    }


    loadMenu() {
        const OPCI_Estado = "";
        const data = this.sessionService.getCurrentSession();
        if (data.menu.length !== 0) {

            this.menuList = data.menu.filter(
                (x) => { return x.OPCI_Estado.toLowerCase().indexOf("A".toLowerCase()) !== -1 });

        }
    }

    loadMenuClassic() {
        const session = this.sessionService.getCurrentSession();
        let opciones: any = [];
        opciones = session.menu;

        let item = opciones.findIndex((obj: any) => obj.OPCI_Menu == 'REP');
        if (item >= 0)
            this.REP = opciones[item].OPCI_Estado == 'A' ? true : false;

        item = opciones.findIndex((obj: any) => obj.OPCI_Menu == 'LOGIS');
        if (item >= 0)
            this.LOGIS = opciones[item].OPCI_Estado == 'A' ? true : false;

        item = opciones.findIndex((obj: any) => obj.OPCI_Menu == 'SERV');
        if (item >= 0)
            this.SERV = opciones[item].OPCI_Estado == 'A' ? true : false;

        item = opciones.findIndex((obj: any) => obj.OPCI_Menu == 'COMB');
        if (item >= 0)
            this.COMB = opciones[item].OPCI_Estado == 'A' ? true : false;

        item = opciones.findIndex((obj: any) => obj.OPCI_Menu == 'RRHH');
        if (item >= 0)
            this.RRHH = opciones[item].OPCI_Estado == 'A' ? true : false;

        item = opciones.findIndex((obj: any) => obj.OPCI_Menu == 'NSTOCK');
        if (item >= 0)
            this.NSTOCK = opciones[item].OPCI_Estado == 'A' ? true : false;

        item = opciones.findIndex((obj: any) => obj.OPCI_Menu == 'DFLOTA');
        if (item >= 0)
            this.DFLOTA = opciones[item].OPCI_Estado == 'A' ? true : false;
    }

    ngOnDestroy() {
        this.routerObj.unsubscribe();
    }
    initLeftSidebar() {
        const _this = this;
        // Set menu height
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
        // this.authService.logout().subscribe((res) => {
        //   if (!res.success) {
        //     this.router.navigate(["/authentication/signin"]);
        //   }
        // });
    }

    Redireccionar(OPCION: string) {
        this.router.navigate(['admin/reportes/grafico-reporte', OPCION]);
        //this.isActive(this.currentRoute);
    }


    isActive(ruta: any): boolean {
        this.router.events.subscribe((event: any) => {
            event instanceof NavigationEnd;
            this.currentRoute = event.url;
        });
        let activo = false;
        if (this.currentRoute == ruta) {
            activo = true;
        }
        return activo;
    }
}
