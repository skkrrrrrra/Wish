export class UserLoginResponse {
  resultType = ''
  errors = []
  data: Data = {
    token: '',
    userData:[]
  }
}

export interface Data {
  token: string
  userData: []
}

export interface UserData {
  id: number
  firstName: string
  lastName: string
  role: string
  userName: string
  email: string
}

