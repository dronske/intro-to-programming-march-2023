import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { ItemEntityForm, ItemEntityRequestModel } from '../../models/items.models';
import { itemsEvents } from '../../state/actions/items.actions';

@Component({
  selector: 'app-new',
  templateUrl: './new.component.html',
  styleUrls: ['./new.component.css']
})
export class NewComponent {
  constructor(private readonly store: Store) {}

  form = new FormGroup<ItemEntityForm>({
    name: new FormControl<string>('', {
      nonNullable: true,
      validators: [Validators.required, Validators.maxLength(50)]
    }),
    description: new FormControl<string>('', {
      nonNullable: true,
      validators: [Validators.maxLength(100)]
    }),
    link: new FormControl<string>('', {
      nonNullable: true,
      validators: [Validators.required]
    })
  });

  get name() { return this.form.controls.name; }
  get description() { return this.form.controls.description }
  get link() { return this.form.controls.link }

  addIt() {
    if(this.form.valid) {
      const payload = this.form.value as ItemEntityRequestModel;
      this.store.dispatch(itemsEvents.itemCreationRequested({payload}));
    } else {
      // invalid filled form
    }
  }
}