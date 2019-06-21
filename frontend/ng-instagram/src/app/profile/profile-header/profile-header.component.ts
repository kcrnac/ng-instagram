import { Component, OnInit, Input } from '@angular/core';
import { User } from '../../core/models/user.model';

@Component({
  selector: 'app-profile-header',
  templateUrl: './profile-header.component.html',
  styleUrls: ['./profile-header.component.scss']
})
export class ProfileHeaderComponent implements OnInit {

  @Input() user: User;

  constructor() { }

  ngOnInit() {
  }

}
