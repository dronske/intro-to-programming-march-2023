import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { catchError, map, mergeMap, of, switchMap } from "rxjs";
import { errorsEvents } from "../actions/errors.actions";
import { itemsCommands, itemsDocuments, itemsEvents } from "../actions/items.actions";
import { ItemEntity } from "../reducers/items.reducer";

@Injectable()
export class ItemsEffects {

    loadItems$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(itemsCommands.loadTheItems),
            switchMap(() => this.client.get<{data: ItemEntity[]}>('http://localhost:1340/learning-resources'))
            
        ).pipe(map((response) => response.data),
        map((payload) => itemsDocuments.items({ payload })))
    });

    addItem$ = createEffect(() => {
        return this.actions$.pipe(
          ofType(itemsEvents.itemCreationRequested),
          mergeMap((a) => this.client.post<ItemEntity>('http://localhost:1340/learning-resources', a.payload)
            .pipe(map((response) => itemsDocuments.item({payload: response})),
            catchError(() => of(errorsEvents.errorHappened({message: 'uh oh'})))
            )) // good for non-safe (non-GET) operations
        );
    });

    constructor(private actions$: Actions, private client : HttpClient) {

    }
}