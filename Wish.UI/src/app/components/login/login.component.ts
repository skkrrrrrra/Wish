import { Component, OnInit } from '@angular/core';
import { UserLoginRequest } from 'src/app/models/Auth/UserLoginRequest';
import { UserLoginResponse } from 'src/app/models/Auth/UserLoginResponse';
import { AuthService } from 'src/app/services/auth.service';
import { AppComponent } from 'src/app/app.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  styles: [
    `.successResult{margin-left:550px; font-size:25px; color:green;}
    .failedResult{margin-left:420px; font-size:25px; color:red;}`
  ]
})
export class LoginComponent {
  result = ''
  isSuccess = false;
  user = new UserLoginRequest();
  constructor(private authService: AuthService)
  {
  }

  login(user: UserLoginRequest)
  {
    this.authService.login(user).subscribe((loginResponse : UserLoginResponse) =>
    {
      if(loginResponse.resultType == 0)
      {
        this.isSuccess = true;
        this.result = 'Success'
        localStorage.setItem('fullname', loginResponse.data.userData.fullname)
        localStorage.setItem('authToken', loginResponse.data.token);
      }
      else{
        this.result = loginResponse.errors.toString()
        this.isSuccess = false;
      }
    })
  }
}
