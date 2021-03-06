import { NgModule } from "@angular/core";
import { AuthRoutingModule } from './auth-routing.module';
import { NoAuthGuard } from './no-auth-guard.service';
import { LoginComponent } from './login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RegisterComponent } from './register/register.component';
import { CommonModule } from "@angular/common";
import { SharedModule } from "../shared/shared.module";

@NgModule({
    imports: [
        AuthRoutingModule,
        FormsModule,
        ReactiveFormsModule,
        CommonModule,
        SharedModule
    ],
    declarations: [
        LoginComponent,
        RegisterComponent
    ],
    providers: [
        NoAuthGuard
    ]
})
export class AuthModule { }