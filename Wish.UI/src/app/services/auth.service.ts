import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { UserRegisterRequest } from '../models/Auth/UserRegisterRequest';
import { UserLoginRequest } from '../models/Auth/UserLoginRequest';
import { UserRegisterResponse } from '../models/Auth/UserRegisterResponse';
import { UserLoginResponse } from '../models/Auth/UserLoginResponse';
import {from} from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class AuthService {

  constructor(private http:HttpClient)
  {
  }
  public register(user: UserRegisterRequest): Observable<UserRegisterResponse>{
    return this.http.post<UserRegisterResponse>('https://localhost:7043/api/auth/register', user,
    {
      headers: {
        'Access-Control-Allow-Origin': '*',
      },
    });
  }

  public login(user: UserLoginRequest): Observable<UserLoginResponse>{
    return this.http.post<UserLoginResponse>('https://localhost:7043/api/auth/login', user,
    {
      headers: {
        'Access-Control-Allow-Origin': '*',
      }
    });
  }
}
