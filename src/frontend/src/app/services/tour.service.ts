import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router, UrlSerializer } from '@angular/router';
import { TourDto } from '../models/Tour/TourDto'
import { GetToursQuery } from '../models/Tour/GetToursQuery'
import { Observable } from 'rxjs';
import { PagedListDto } from '../models/PagedListDto';
import { backendUrl } from 'src/environments/environment';
import { CreateTourCommand } from '../models/Tour/CreateTourCommand';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class TourService {
  backendPath:string = "/api/tour";
  
  constructor(private http:HttpClient, private router:Router, private serializer:UrlSerializer) { }

  getTours(query: GetToursQuery): Observable<PagedListDto<TourDto>> {
    const url = backendUrl + this.backendPath + `/get?page=${query.page}&pageSize=${query.pageSize}`;
    console.log(url);
    
    return this.http.get<PagedListDto<TourDto>>(url);
  }

  createTour(command:CreateTourCommand):Observable<any> {
    const url = backendUrl + this.backendPath + '/create';
    return this.http.post<any>(url, command, { headers: this.getHeadersWithJwt()});
  }

  getHeadersWithJwt() {
    const headers = new HttpHeaders()
      .set('Content-Type', 'application/json')
      .set('Authorization', `Bearer ${localStorage.getItem('token')}`);
    return headers;
  }
}
