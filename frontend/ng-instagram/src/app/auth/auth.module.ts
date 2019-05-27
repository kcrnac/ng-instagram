import { NgModule } from "@angular/core";
import { AuthComponent } from './auth.component';
import { AuthRoutingModule } from './auth-routing.module';
import { NoAuthGuard } from './no-auth-guard.service';

@NgModule({
    imports: [
        AuthRoutingModule
    ],
    declarations: [
        AuthComponent
    ],
    providers: [
        NoAuthGuard
    ]
})
export class AuthModule { }