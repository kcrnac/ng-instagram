import {
    HttpEvent,
    HttpInterceptor,
    HttpHandler,
    HttpRequest,
    HttpErrorResponse
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { Injectable } from '@angular/core';
import { SharedService } from '../../shared/services/shared.service';

@Injectable()
export class HttpErrorInterceptor implements HttpInterceptor {

    constructor(
        private sharedService: SharedService
    ) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request)
            .pipe(retry(1),
                catchError((error: HttpErrorResponse) => {

                    if (error.error instanceof ErrorEvent) {
                        // client-side error
                    } else {
                        // server-side error
                        debugger;
                        this.sharedService.parseServerErrorsAndToast(error)
                    }
                    return throwError(error);
                })
            )
    }
}