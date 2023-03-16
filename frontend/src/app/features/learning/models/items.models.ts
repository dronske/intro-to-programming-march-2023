import { FormControl } from "@angular/forms"
import { ItemEntity } from "../state/reducers/items.reducer"

export type ItemEntityRequestModel = Omit<ItemEntity, 'id'>

type FormDataType<T> = {
  [Property in keyof T]: FormControl<T[Property]>
}

export type ItemEntityForm = FormDataType<ItemEntityRequestModel>