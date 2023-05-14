import { Component } from '@angular/core';
import { UserRegisterRequest } from 'src/app/models/Auth/UserRegisterRequest';
import { UserRegisterResponse } from 'src/app/models/Auth/UserRegisterResponse';
import { AuthService } from 'src/app/services/auth.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})

export class RegisterComponent {

  user = new UserRegisterRequest();
  result = ''
  isSuccess = false;
  constructor(private authService: AuthService)
  {
  }

  register(user: UserRegisterRequest)
  {
    if(
      this.user.password != ''
      && user.email != ''
      && user.fullname != ''
      && user.phoneNumber != ''
      && user.username != '')
      {
        this.authService.register(user).subscribe((registerResponse : UserRegisterResponse) =>
        {
          if(registerResponse.resultType == 0)
          {
            this.result = 'Successed'
            this.isSuccess = true;
          }
          else
          {
            this.result = registerResponse.errors.toString()
            this.isSuccess = false;
          }
        })
      }
      else
      {
        this.result = 'Fill in all the fields'
        this.isSuccess = false;
      }
  }



}
