import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { UserRegisterRequest } from '../models/Auth/UserRegisterRequest';
import { UserLoginRequest } from '../models/Auth/UserLoginRequest';
import { UserLoginResponse } from '../models/Auth/UserLoginResponse';

@Injectable({
  providedIn: 'root'
})

export class AuthService {

  constructor(private http:HttpClient)
  {
  }
  public register(user: UserRegisterRequest): Observable<UserRegisterRequest>{
    return this.http.post<any>('https://localhost:7043/api/auth/register', user,
    {
      headers: new HttpHeaders({
        'Access-Control-Allow-Origin': '*',
      })
    });
  }

  public login(user: UserLoginRequest): Observable<UserLoginResponse>{
    return this.http.post<UserLoginResponse>('https://localhost:7043/api/auth/login', user);
  }
}
