import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../core/services/user.service';
import { User } from '../core/models/user.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {

  user: User;

  constructor(
    private route: ActivatedRoute,
    private userService: UserService,
    private toastrService: ToastrService,
    private router: Router
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
          if (user == null) {
            this.toastrService.error('User does not exist');
            this.router.navigateByUrl('/');
          }
          this.user = user;
        })
    }
  }

}
