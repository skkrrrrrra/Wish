import { Component, OnInit } from '@angular/core';
import { UserLoginRequest } from 'src/app/models/Auth/UserLoginRequest';
import { UserLoginResponse } from 'src/app/models/Auth/UserLoginResponse';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  user = new UserLoginRequest();
  constructor(private authService: AuthService)
  {
  }

  login(user: UserLoginRequest)
  {
    this.authService.login(user).subscribe((loginResponse : UserLoginResponse) =>
    {
      localStorage.setItem('authToken', loginResponse.data.token);
    })
  }
}
