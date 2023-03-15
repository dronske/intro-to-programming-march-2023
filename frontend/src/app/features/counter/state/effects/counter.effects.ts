import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType, concatLatestFrom } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { z } from 'zod';
import { catchError, filter, map, of, tap } from 'rxjs';
import { selectCounterBranch } from '..';
import { counterCommands, counterDocuments, counterEvents } from '../actions/counter.actions';
import { CounterState } from '../reducers/counter.reducer';

@Injectable()
export class CounterEffects {

    private readonly CountDataSchema = z.object({
        current: z.number(),
        by: z.union([
            z.literal(1),
            z.literal(3),
            z.literal(5)
        ])
    });

    // logItAll$ = createEffect(
    //     () => {
    //     return this.actions$.pipe(tap((action) => console.log(action.type))); // =>
    //     },
    //     { dispatch: false },
    //     );

    // Every time an action of type increment, decrement, reset, countBySet happens, write the counter state to local storage

    writeCounterState = createEffect(
        () => {
            return this.actions$.pipe(
                ofType(counterEvents.countBySet, counterEvents.decrementButtonClicked, counterEvents.incrementButtonClicked, counterEvents.resetClicked),
                concatLatestFrom(() => this.store.select(selectCounterBranch)),
                tap(([_, data]) => localStorage.setItem('counter-state', JSON.stringify(data)))
            );
        }, { dispatch: false },
    );

    // Check local storage, provide a document only if there is one there
    loadCounterState$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(counterCommands.loadCounterState),
            map(() => localStorage.getItem('counter-state')),
            filter(storedValue => storedValue !== null),
            map(theString => JSON.parse(theString!) as CounterState),
            map(susObject => this.CountDataSchema.parse(susObject)),
            map(counterState => counterDocuments.counterState({payload: counterState})), // the action to send to the state
            catchError(() => {
                console.log("Uh oh");
                localStorage.clear();
                return of({type: 'Localstorage Error'});
            })   
        );
    }
    );

    constructor(private readonly actions$: Actions, private readonly store: Store) {}
}