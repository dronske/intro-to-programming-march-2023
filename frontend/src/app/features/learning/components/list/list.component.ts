import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { selectItemsEntitiesArray } from '../../state';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent {

  constructor(private readonly store: Store) {}

  items$ = this.store.select(selectItemsEntitiesArray);

}
