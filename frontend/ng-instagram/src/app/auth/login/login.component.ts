import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { UserService } from '../../core/services/user.service';
import { Router } from '@angular/router';
import { SharedService } from '../../shared/services/shared.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  errors: Array<string> = [];
  isSubmitting: boolean = false;

  constructor(
    private router: Router,
    private userService: UserService,
    private sharedService: SharedService,
    private toastrService: ToastrService,
    private fb: FormBuilder) {

    this.loginForm = this.fb.group({
      username: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required)
    });
  }

  ngOnInit() {
  }

  onSubmit() {
    this.isSubmitting = true;
    this.errors = [];

    this.userService.attemptAuth(this.loginForm.value)
      .subscribe((data) => {
        this.router.navigateByUrl('/');
      },
        err => {
          var errors = this.sharedService.parseServerErrors(err);

          errors.forEach((error) => { this.toastrService.error(error) });
          this.isSubmitting = false;
        });
  }

  get form() { return this.loginForm.controls };
}
