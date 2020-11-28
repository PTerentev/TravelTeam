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

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  backendUrl:string = "http://localhost:52732/api/account";

  constructor(private http:HttpClient, private router:Router, private serializer:UrlSerializer) { }

  register(command:RegisterUserCommand):Observable<any> {
    const url = this.backendUrl + '/register'
    return this.http.post<any>(url, command, httpOptions);
  }

  login(command:LoginUserCommand):Observable<LoginUserCommandResult> {
    const url = this.backendUrl + '/login'
    return this.http.post<LoginUserCommandResult>(url, command, httpOptions);
  }

  getInfo(query:GetUserInfoQuery):Observable<UserDto> {
    const url = this.backendUrl + `/register/?userId=${query.userId}`;
    return this.http.get<UserDto>(url);
  }
}
