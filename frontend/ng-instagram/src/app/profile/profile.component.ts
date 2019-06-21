import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../core/services/user.service';
import { User } from '../core/models/user.model';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {

  username: string;
  user: User;

  constructor(
    private route: ActivatedRoute,
    private userService: UserService
  ) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.onUserChange(params);
    });
  }

  onUserChange(params) {
    if (params != null) {
      this.userService.getUserByUsername(params.username)
        .subscribe((user) => {
          this.user = user;
        })
    }
  }

}
