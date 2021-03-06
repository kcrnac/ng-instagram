import { NgModule } from "@angular/core";
import { RouterModule, Routes } from '@angular/router';
import { NoAuthGuard } from './no-auth-guard.service';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
    {
        path: 'login',
        component: LoginComponent,
        canActivate: [NoAuthGuard]
    },
    {
        path: 'register',
        component: RegisterComponent,
        canActivate: [NoAuthGuard]
    }
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class AuthRoutingModule { }