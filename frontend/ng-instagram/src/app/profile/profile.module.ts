import { NgModule } from '@angular/core';
import { ProfileComponent } from './profile.component';
import { ProfileRoutingModule } from './profile-routing.module';
import { ProfileHeaderComponent } from './profile-header/profile-header.component';

@NgModule({
    imports: [
        ProfileRoutingModule
    ],
    declarations: [
        ProfileComponent,
        ProfileHeaderComponent
    ],
    providers: []
})
export class ProfileModule { }