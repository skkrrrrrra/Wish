export class ProductResponse {
  resultType = 0
  errors = []
  data: Data = {
    id: 0,
    title: '',
    description: '',
    categoryId: 0,
    pictureImage: '',
    weight: 0,
    material:{
      id: 0,
      type: 0,
      title: ''
    },
    count: 0,
    price: 0,
    attributes:[]

  }
}

export interface Data {
  id: 0
  title: string
  description: string
  categoryId: number
  pictureImage: string
  weight: number
  material: Material
  count: number
  price: number
  attributes: Attribute[]
}

export interface Material {
  id: number
  type: number
  title: string
}

export interface Attribute {
  id: number
  productId: number
  title: string
  value: string
}
