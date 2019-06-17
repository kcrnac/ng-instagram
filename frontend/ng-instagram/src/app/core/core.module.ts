import { NgModule, ErrorHandler } from "@angular/core";
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { HttpTokenInterceptor } from './interceptors/http.token.interceptor';
import { ApiService } from './services/api.service';
import { JwtService } from './services/jwt.service';
import { UserService } from './services/user.service';
import { AuthGuard } from './services/auth-guard.service';
import { GlobalErrorHandler } from "./errors/global-error.handler";

@NgModule({
    imports: [],
    providers: [
        { provide: HTTP_INTERCEPTORS, useClass: HttpTokenInterceptor, multi: true },
        { provide: ErrorHandler, useClass: GlobalErrorHandler },
        ApiService,
        JwtService,
        UserService,
        AuthGuard
    ],
    declarations: []
})
export class CoreModule { }