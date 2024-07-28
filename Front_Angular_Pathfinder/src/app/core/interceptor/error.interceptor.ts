import { Injectable } from "@angular/core";
import {
    HttpRequest,
    HttpHandler,
    HttpEvent,
    HttpInterceptor,
} from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { catchError } from "rxjs/operators";
import { SessionService } from "../service/session.service";

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    constructor(
        private sessionService: SessionService
    ) { }

    intercept(
        request: HttpRequest<any>,
        next: HttpHandler
    ): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(
            catchError((err) => {
                console.log(err);
                if (err.status === 401) {
                    this.sessionService.logout();
                }
                return throwError(() => err);
            })
        );
    }
}
