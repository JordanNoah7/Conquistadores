import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EncryptService } from "./encrypt.service";

const TIMER_TAG: string = '9Dl0KQrqjXEJUDLLnalvs3IHSx4D1o';
const DATES_TAG: string = '1W4lzCkyDp6ITgYv6C74RhZQrG6s2h';
const TOKEN_TAG: string = 'QrHIySHG2C0Ty1CV1rESoNYl6Csf3m';
const SESSION_TAG: string = 'TfHgygHJ2C0TKLdCj1rESoGYlhCsv64d';
const EMPRESA_TAG: string = 'SR20ygHJ2C0TKLdCj1rESoGYlhCsv65d';

@Injectable()
export class SessionService {
    private localStorageService;
    private currentSession: any = null;
    private currentEmpresa: any = null;
    private url: string = '';
    private manual: string = '';
    private persistentDate: any = null;

    private minutos_disponibles = 0;
    private default_minutos = 30;
    private time_remaing = 0;
    private date_catch: Date | null = null;
    private contador: any = null;
    private contadorMin: any = null;

    private inputKey: string | null = null;
    private inputCode: string | null = null;
    private existKeys: boolean = true;
    private contadorRequest: number = 0;

    public Logo: any = null;
    private temporalData: any = null;

    constructor(
        private router: Router,
        private route: ActivatedRoute,
        private http: HttpClient,
        private encrypt: EncryptService
    ) {
        this.localStorageService = localStorage;
        this.route.queryParams.subscribe((res) => {
            this.contadorRequest++;
            if (this.contadorRequest > 1) {
                this.inputKey = res.key;
                this.inputCode = res.cod;
                if (this.inputKey && this.inputCode && !this.existKeys) {
                    this.validarToken();
                } else if (this.existKeys) {
                    this.router.navigate(['/enviroment']);
                } else {
                    this.router.navigate(['/auth/login']);
                }
            }
        });
        this.currentSession = this.loadSessionData();
        this.getMinutosDisponibles();
    }

    private async validarToken() {
        const payload = {
            KeyToken: (<any>this.inputKey).replace(/\s+/g, '+'),
            APLI_CodApli: this.inputCode,
        };
        const result = await this.ValidarPorToken(payload);
    }

    getDefaultOptions = (): HttpHeaders => {
        const headers = new HttpHeaders();
        headers.set('Accept', 'application/json');
        headers.set('Content-Type', 'application/json');
        return headers;
    };

    public ValidarPorToken = (payload: any) =>
        new Promise<any>((resolve) =>
            this.http
                .post<any>('/auth/ValidarPorToken', payload, {
                    headers: this.getDefaultOptions(),
                })
                .subscribe(
                    (data) => resolve(data),
                    (err) => resolve(null)
                )
        );

    startCounter() {
        this.contador = setTimeout(() => {
            this.logout();
        }, this.time_remaing);
        this.contadorMin = setInterval(() => {
            this.changeTimes();
        }, 60000);
    }

    renovateCounter() {
        this.endCounter();
        this.startCounter();
    }

    endCounter() {
        clearTimeout(this.contador);
        clearTimeout(this.contadorMin);
    }

    endSession() {
        this.endCounter();
        this.localStorageService.clear();
        this.minutos_disponibles = 0;
        this.time_remaing = 0;
        this.date_catch = null;
        this.contador = null;
        this.contadorMin = null;
    }

    changeTimes() {
        this.minutos_disponibles--;
        this.localStorageService.setItem(
            TIMER_TAG,
            this.encrypt.encryptAuth(JSON.stringify(this.minutos_disponibles))
        );

        if (this.date_catch) {
            const date_saved = new Date(this.date_catch);
            const date_now = new Date();
            const time_elapsed = (date_now.getTime() - date_saved.getTime()) / 60000;
            if (time_elapsed > this.default_minutos) {
                this.logout();
                return;
            }
        }
    }

    setMinutosDisponibles(minutos: number) {
        if (!minutos || minutos == null || minutos == 0) {
            return;
        }
        this.minutos_disponibles = minutos;
        this.default_minutos = minutos;
        this.date_catch = new Date();
        this.time_remaing = this.minutos_disponibles * 60 * 1000;
        this.localStorageService.setItem(TIMER_TAG, this.encrypt.encryptAuth(JSON.stringify(minutos)));
        this.localStorageService.setItem(DATES_TAG, this.encrypt.encryptAuth(JSON.stringify(this.date_catch)));
        this.renovateCounter();
    }

    private getMinutosDisponibles() {
        const min_disp = this.encrypt.decryptAuth(
            this.localStorageService.getItem(TIMER_TAG)
        );
        this.minutos_disponibles = parseFloat(min_disp) ? parseFloat(min_disp) : 0;
        this.minutos_disponibles =
            this.minutos_disponibles < 0 ? 0 : this.minutos_disponibles;
        const tim_rem = this.encrypt.decryptAuth(
            this.localStorageService.getItem(DATES_TAG)
        );
        this.date_catch = new Date(tim_rem) ? new Date(tim_rem) : new Date();
        this.time_remaing = this.minutos_disponibles * 60 * 1000;
        if (this.time_remaing <= 0) {
            return;
        }
        this.startCounter();
    }

    public setCurrentSession(session: any): void {
        this.currentSession = session;
        this.localStorageService.setItem(
            SESSION_TAG,
            this.encrypt.encryptAuth(JSON.stringify(session))
        );
    }

    loadSessionData(): any {
        let sessionStr: string = this.encrypt.decryptAuth(this.localStorageService.getItem(SESSION_TAG));
        return sessionStr ? JSON.parse(sessionStr) : null;
    }

    getCurrentSession(): any {
        return this.currentSession;
    }

    removeCurrentSession(): boolean {
        this.localStorageService.removeItem(SESSION_TAG);
        this.currentSession = null;
        return (
            !this.localStorageService.getItem(SESSION_TAG) && !this.currentSession
        );
    }

    isAuthenticated(): boolean {
        return this.getCurrentToken() != null ? true : false;
    }

    getCurrentToken(): string {
        var session = this.getCurrentSession();
        let token = session && session.token ? session.token : null;
        return token;
    }

    getCurrentContext(): any {
        var session = this.getCurrentSession();
        return session && session.context ? session.context : null;
    }

    setCurrentContext(context: any): void {
        this.currentSession.context = context;
        this.setCurrentSession(this.currentSession);
    }

    removeCurrentContext(): void {
        this.setCurrentContext(null);
    }

    logout(): void {
        const session = this.getCurrentSession();
        this.endSession();
        this.removeCurrentSession();
        this.router.navigate(['/auth/login']);
    }

    public configureTarget(data: any) {
        const session = Object.freeze({
            token: {
                UsuaId: data.Usuario.UsuaId,
                PersId: data.PersId ? data.PersId : data.TutoId,
                UsuaNombre: data.PersId ? data.PersNombres + ' ' + data.PersApellidoPaterno + ' ' + data.PersApellidoMaterno : data.TutoNombres + ' ' + data.TutoApellidoPaterno + ' ' + data.TutoApellidoMaterno,
                PersSexo: data.PersSexo
            },
            menu: (() => {
                return data.Usuario.UsuaRoles;
            })(),
            user: {
                UsuaUsuario: data.Usuario.UsuaUsuario,
                UsuaId: data.Usuario.UsuaId,
                PersDni: data.PersId ? data.PersDni : data.TutoDni
            },
            PassForce: data.PassForce
        });
        this.setCurrentSession(session);
    }

    public configureUsuario(data: any) {
        const session = this.getCurrentSession();
        session.enviroment.Usuario = data;
        session.token.Usuario = data.USER_CodUsr;
        this.setCurrentSession(session);
    }
}
