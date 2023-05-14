import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { ProductResponse } from '../models/Product/ProductResponse';
import ProductDetailInfo from '../models/Product/ProductDetailInfo';



@Injectable({
  providedIn: 'root'
})

export class ProductService {

  constructor(private http:HttpClient)
  {
  }
  public getAllProducts(categoryId: number, pageNumber: number, pageSize: number) : Observable<ProductResponse>
  {
    return this.http.get<ProductResponse>(
      'https://localhost:7043/api/catalog/'
      + categoryId
      + "?pageNumber="
      + pageNumber
      + "&pageSize="
      + pageSize
      );
  }
  public addToCartshop(productId: number) : Observable<any>
  {
    return this.http.post<any>(
      'https://localhost:7043/api/cartshop/add', productId,
      {
        headers: {
          'Access-Control-Allow-Origin': '*',
        },
      });
  }

  public getItemInfo(productId: number) : Observable<ProductDetailInfo>
  {
    return this.http.get<ProductDetailInfo>(
      'https://localhost:7043/api/catalog/product/' + productId,
      {
        headers: {
          'Access-Control-Allow-Origin': '*',
        },
      });
  }
}
