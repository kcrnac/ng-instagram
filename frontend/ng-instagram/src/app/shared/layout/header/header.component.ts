import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../core/services/user.service';
import { User } from '../../../core/models/user.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-layout-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  constructor(
    private router: Router,
    private userService: UserService
  ) { }

  currentUser: User;

  ngOnInit() {
    this.userService.currentUser.subscribe(
      (userData) => {
        this.currentUser = userData;
      }
    );
  }

  logout() {
    this.userService.purgeAuth();
    this.router.navigateByUrl('/');
  }
}
