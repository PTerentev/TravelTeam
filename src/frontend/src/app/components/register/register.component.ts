import { FormControl, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: [
    './register.component.css',
    './../../../../node_modules/bootstrap/dist/css/bootstrap.min.css',
    './../../styles/form-styles.css'
  ]
})
export class RegisterComponent implements OnInit {
  hide = true;
  constructor() { }

  email = new FormControl('', [Validators.required, Validators.email]);

  getErrorMessage() {
    if (this.email.hasError('required')) {
      return 'You must enter a value';
    }

    return this.email.hasError('email') ? 'Not a valid email' : '';
  };

  ngOnInit(): void {
  }

}
