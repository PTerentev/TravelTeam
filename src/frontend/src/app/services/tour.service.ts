import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router, UrlSerializer } from '@angular/router';
import { TourShortDto } from '../models/Tour/TourShortDto'
import { GetToursQuery } from '../models/Tour/GetToursQuery'
import { Observable } from 'rxjs';
import { PagedListDto } from '../models/PagedListDto';

@Injectable({
  providedIn: 'root'
})
export class TourService {
  backendUrl:string = "http://localhost:52732/api/tour";
  
  constructor(private http:HttpClient, private router:Router, private serializer:UrlSerializer) { }

  getTours(query: GetToursQuery): Observable<PagedListDto<TourShortDto>> {
    const url = this.backendUrl + `/get?page=${query.page}&pageSize=${query.pageSize}`;
    console.log(url);
    
    return this.http.get<PagedListDto<TourShortDto>>(url);
  }
}
