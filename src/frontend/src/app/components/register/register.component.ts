import { Component, OnInit } from '@angular/core';
import { RegisterUserCommand } from '../../models/Account/RegisterUserCommand'
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: [
    './register.component.css',
    './../../styles/form-styles.css'
  ]
})

export class RegisterComponent implements OnInit {
  command:RegisterUserCommand;
  repeatPassword:string = '';

  constructor() { }

  ngOnInit(): void {
    this.command = new RegisterUserCommand();
  }

  submit(form: NgForm){
    console.log(this.command);
  }

}
