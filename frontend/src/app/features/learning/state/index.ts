import { ActionReducerMap, createFeatureSelector, createSelector } from "@ngrx/store";
import * as fromItems from './reducers/items.reducer'
import * as fromErrors from './reducers/errors.reducer'

export const featureName = "learningFeature";

export interface LearningState {
    items: fromItems.ItemsState;
    errors: fromErrors.ErrorsState;
}

export const reducers: ActionReducerMap<LearningState> = {
    items: fromItems.reducer,
    errors: fromErrors.reducer
};

const selectFeature = createFeatureSelector<LearningState>(featureName);

const selectItemsBranch = createSelector(selectFeature, f => f.items)
const selectErrorsBranch = createSelector(selectFeature, f => f.errors);

export const { selectAll: selectItemsEntitiesArray } = fromItems.adapter.getSelectors(selectItemsBranch);

export const selectHasError = createSelector(selectErrorsBranch, b => b.hasError);
export const selectErrorMessage = createSelector(selectErrorsBranch, b => b.errorMessage);