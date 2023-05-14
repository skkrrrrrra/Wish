export class UserLoginResponse {
  resultType = 0
  errors = []
  data = {
    token: '',
    userData: {
      id: 0,
      fullname: "",
      role: "",
      userName: "",
      email: ""
    }
  }
}
