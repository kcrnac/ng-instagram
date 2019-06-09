import { NgModule } from "@angular/core";
import { AuthComponent } from './auth.component';
import { AuthRoutingModule } from './auth-routing.module';
import { NoAuthGuard } from './no-auth-guard.service';
import { LoginComponent } from './login/login.component';

@NgModule({
    imports: [
        AuthRoutingModule
    ],
    declarations: [
        AuthComponent,
        LoginComponent
    ],
    providers: [
        NoAuthGuard
    ]
})
export class AuthModule { }