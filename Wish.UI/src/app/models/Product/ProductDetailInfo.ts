export default interface Root {
  resultType: number
  errors: any[]
  data: Data
}

export interface Data {
  id: number
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
  type: number
  title: string
  id: number
}

export interface Attribute {
  productId: number
  title: string
  value: string
  id: number
}















// export default class Response {
//   resultType = 0
//   errors:any = []
//   data:Data = {
//     id: 0,
//     title: '',
//     description: '',
//     categoryId: 0,
//     pictureImage: '',
//     weight: 0,
//     material: {
//       type: 0,
//       title: '',
//       id: 0,
//     },
//     count: 0,
//     price: 0,
//     attributes: [
//       {
//         productId: 0,
//         title: '',
//         value: '',
//         id: 0
//       },
//     ]
//   }
// }
// export interface Data {
//   id: number
//   title: string
//   description: string
//   categoryId: number
//   pictureImage: string
//   weight: number
//   material: Material
//   count: number
//   price: number
//   attributes: Attribute[]
// }
// export interface Material {
//   type: number
//   title: string
//   id: number
// }
// export class Attribute {
//   productId = 0
//   title = ''
//   value = ''
//   id = 0
// }

