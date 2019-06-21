import { NgModule } from "@angular/core";
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../core/services/auth-guard.service';
import { ProfileComponent } from './profile.component';

const routes: Routes = [
    {
        path: ':username',
        component: ProfileComponent,
        canActivate: [AuthGuard],
        pathMatch: 'full'
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class ProfileRoutingModule { }