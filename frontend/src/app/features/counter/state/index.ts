import { ActionReducerMap, createFeatureSelector, createSelector } from "@ngrx/store";
import * as fromCounter from './reducers/counter.reducer'

export const featureName = "counterFeature";

export interface CounterState {
    counter: fromCounter.CounterState;
}

export const reducers: ActionReducerMap<CounterState> = {
    counter: fromCounter.reducer,
};

const selectFeature = createFeatureSelector<CounterState>(featureName);

export const selectCounterBranch = createSelector(
    selectFeature,
    f => f.counter
);

export const selectCounterCurrent = createSelector(
    selectCounterBranch,
    b => b.current
);

export const selectCountBy = createSelector(selectCounterBranch, b => b.by);