import { Component, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../../core/services/user.service';
import { SharedService } from '../../shared/services/shared.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup;
  errors: Array<string> = [];
  isSubmitting = false;

  constructor(
    private router: Router,
    private userService: UserService,
    private fb: FormBuilder,
    private sharedService: SharedService,
    private toastrService: ToastrService
  ) {
    this.registerForm = this.fb.group({
      email: new FormControl('', [Validators.required, Validators.email]),
      name: new FormControl('', Validators.required),
      username: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required)
    });
  }

  ngOnInit() {
  }

  onSubmit() {

    this.isSubmitting = true;
    this.errors = [];
    this.userService.attemptRegister(this.registerForm.value)
      .subscribe((data) => {
        if (data && !data.succeeded) {

          this.sharedService.parseServerErrorsAndToast(data);
          this.isSubmitting = false;

        } else {

          this.toastrService.success("User successfuly created.")
          this.router.navigateByUrl('/login');

        }
      },
        err => {
          this.isSubmitting = false;
        });
  }

  get form() { return this.registerForm.controls };

}
