import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'ng-instagram';

  constructor(private toastrService: ToastrService) {
  }

  ngOnInit() {
    this.toastrService.error('Test error');
  }
}
