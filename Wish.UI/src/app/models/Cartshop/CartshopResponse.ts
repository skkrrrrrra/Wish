export class CartshopResponse {
  resultType = 0
  errors = []
  data:Daum = {
    id: 0,
    title: '',
    pictureImage: '',
    count: 0,
    price: 0
  }
}

export interface Daum {
  id: number
  title: string
  pictureImage: string
  count: number
  price: number
}
