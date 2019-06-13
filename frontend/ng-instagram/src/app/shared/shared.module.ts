import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ShowAuthedDirective } from './show-authed.directive';
import { ListErrorsComponent } from './errors/list-errors.component';
import { CommonModule } from "@angular/common";
import { SharedService } from "./services/shared.service";

@NgModule({
    imports: [
        FormsModule,
        ReactiveFormsModule,
        HttpClientModule,
        RouterModule,
        CommonModule
    ],
    declarations: [
        ShowAuthedDirective,
        ListErrorsComponent
    ],
    exports: [
        FormsModule,
        ReactiveFormsModule,
        HttpClientModule,
        RouterModule,
        ShowAuthedDirective,
        ListErrorsComponent,
    ],
    providers: [
        SharedService
    ]
})
export class SharedModule { }