import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { ProductResponse } from '../models/Product/ProductResponse';


@Injectable({
  providedIn: 'root'
})

export class SearchService {

  constructor(private http:HttpClient)
  {
  }
  public SearchProducts(search:string) : Observable<ProductResponse>
  {
    return this.http.get<ProductResponse>(
      'https://localhost:7043/api/search/' + search);
  }
}
