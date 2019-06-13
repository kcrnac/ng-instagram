import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-list-errors',
  templateUrl: './list-errors.component.html',
  styleUrls: ['./list-errors.component.scss']
})
export class ListErrorsComponent {

  formattedErrors: Array<string> = [];

  @Input()
  set errors(errorList: Array<string>) {
    this.formattedErrors = errorList;
  }

  get errorList() { return this.formattedErrors; }

}
