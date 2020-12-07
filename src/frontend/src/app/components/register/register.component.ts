import { Component, OnInit } from '@angular/core';
import { RegisterUserCommand } from '../../models/Account/RegisterUserCommand'
import { AccountService } from '../../services/account.service'
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

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
  errors:string[];

  constructor(private accountService:AccountService, private router:Router) { }

  ngOnInit(): void {
    this.command = new RegisterUserCommand();
  }

  submit(form: NgForm){

    if (this.validate()) {
      this.accountService.register(this.command).subscribe(
        result => {
          if (!!!result.id) {
            this.router.navigateByUrl("/login");
          }
        },
        error => {
          console.log(error);
          this.errors = ['Ошибка регистрации!'];
          this.errors = this.errors.concat(this.parseBadResponse(error));
        }
      )
    }
  }

  validate():Boolean {
    if (this.command.password != this.repeatPassword)
    {
      this.errors = ["Пароли не совпадают!"];
      console.log("pwd error");
      return false;
    }

    return true;
  }

  parseBadResponse(response: any): string[] {
    return response.error.Extensions.errors[0].Messages;
  }

}
