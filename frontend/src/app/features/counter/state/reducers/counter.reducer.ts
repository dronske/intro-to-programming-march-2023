import { createReducer, on } from "@ngrx/store";
import { ValidCountByValues } from "../../models";
import { counterEvents } from "../actions/counter.actions";

// Describe it for TypeScript
export interface CounterState {
    current: number,
    by: ValidCountByValues
}

// What is the initial state on application start?
const initialState:CounterState = {
    current: 0,
    by: 1
};

// Here's where we decide that if an action happens, does that mean a new state is created?
// Access to current state, as well as action that just happened, and use that to create a new state (if we want)
export const reducer = createReducer(initialState,
    on(counterEvents.incrementButtonClicked, (currentState: CounterState) => ({...currentState, current: currentState.current + currentState.by})),
    on(counterEvents.decrementButtonClicked, (s) => ({...s, current: s.current - s.by})),
    on(counterEvents.resetClicked, (s) => ({...s, current: 0})),
    on(counterEvents.countBySet, (c, a) => ({...c, by: a.by}))
);