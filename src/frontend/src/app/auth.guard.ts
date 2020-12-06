import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AccountService } from './services/account.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  
  constructor(private accountService: AccountService,
              private router: Router,
              private jwtHelper: JwtHelperService) {}

  canActivate(): boolean {
    if (this.accountService.loggedIn() && !this.jwtHelper.isTokenExpired(localStorage.getItem('token'))) {
      return true;
    } else {
      this.router.navigate(['/login']);
      return false;
    }
  }
  
}
