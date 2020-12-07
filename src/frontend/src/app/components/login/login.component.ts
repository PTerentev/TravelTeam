import { Component, OnInit } from '@angular/core';
import { LoginUserCommand } from '../../models/Account/LoginUserCommand';
import { AccountService } from '../../services/account.service';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: [
    './login.component.css', 
    './../../styles/form-styles.css'
  ]
})
export class LoginComponent implements OnInit {
  command:LoginUserCommand;
  errors:string = '';
  constructor(private accountService:AccountService, private router:Router) { }

  ngOnInit(): void {
    this.command = new LoginUserCommand();
  }

  submit(form: NgForm){
    this.accountService.login(this.command).subscribe(
      success => {
        if (!!success.token) {
          localStorage.setItem('token', success.token);
          localStorage.setItem('userId', success.userId);
          this.router.navigate(['/']).then(() => {
            window.location.reload();
          });
        }
      },
      error => {
        this.errors = 'Ошибка входа!'
      }
    )
  }

}
