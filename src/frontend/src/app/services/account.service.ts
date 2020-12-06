import { Injectable } from '@angular/core';
import { LoginUserCommand } from '../models/Account/LoginUserCommand';
import { RegisterUserCommand } from '../models/Account/RegisterUserCommand';
import { LoginUserCommandResult } from '../models/Account/LoginUserCommandResult';
import { GetUserInfoQuery } from '../models/Account/GetUserInfoQuery';
import { UserDto } from '../models/UserDto';
import { Result } from '../models/Result';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Router, UrlSerializer } from '@angular/router';
import { backendUrl } from 'src/environments/environment';
import { JwtHelperService } from '@auth0/angular-jwt';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  backendPath:string = "/api/account";

  constructor(private http:HttpClient, private router:Router,
     private serializer:UrlSerializer,
     private jwtHelper: JwtHelperService) { }

  register(command:RegisterUserCommand):Observable<any> {
    const url = backendUrl + this.backendPath + '/register'
    return this.http.post<any>(url, command, httpOptions);
  }

  login(command:LoginUserCommand):Observable<LoginUserCommandResult> {
    const url = backendUrl + this.backendPath + '/login'
    return this.http.post<LoginUserCommandResult>(url, command, httpOptions);
  }

  getInfo(userId: string):Observable<UserDto> {
    const url = backendUrl + this.backendPath + `/get/?userId=${userId}`;
    return this.http.get<UserDto>(url);
  }

  checkToken():Observable<UserDto> {
    const url = backendUrl + this.backendPath + `/check`;
    return this.http.get<UserDto>(url, { headers: this.getHeadersWithJwt()});
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !!token && !this.jwtHelper.isTokenExpired(token);
  }

  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('userId');
  }

  getHeadersWithJwt() {
    const headers = new HttpHeaders()
      .set('Content-Type', 'application/text')
      .set('Authorization', `Bearer ${localStorage.getItem('token')}`);
    return headers;
  }
}
