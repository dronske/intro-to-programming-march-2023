import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { ValidCountByValues } from '../../models';
import { selectCountBy } from '../../state';
import { counterEvents } from '../../state/actions/counter.actions';

@Component({
  selector: 'app-counter-prefs',
  templateUrl: './counter-prefs.component.html',
  styleUrls: ['./counter-prefs.component.css']
})
export class CounterPrefsComponent {

  constructor(private readonly store: Store) {}

  by$ = this.store.select(selectCountBy);

  setCountBy(by: ValidCountByValues) {
    this.store.dispatch(counterEvents.countBySet({by}));
  }
}
