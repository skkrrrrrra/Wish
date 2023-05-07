import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { ProductResponse } from '../models/Product/ProductResponse';


@Injectable({
  providedIn: 'root'
})

export class CartshopService {

  constructor(private http:HttpClient)
  {
  }
  public getCartshopItems(pageNumber: number, pageSize: number) : Observable<ProductResponse>
  {
    return this.http.get<any>(
      'https://localhost:7043/api/cartshop'
      + "?pageNumber="
      + pageNumber
      + "&pageSize="
      + pageSize
      );
  }
  public deleteFromCartshop(productId:number) : Observable<any>
  {
    return this.http.delete<any>(
      'https://localhost:7043/api/cartshop/' + productId
    );
  }
}
