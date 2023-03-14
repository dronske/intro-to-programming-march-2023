import { createReducer } from "@ngrx/store";

// Describe it for TypeScript
export interface CounterState {
    current: number;
}

// What is the initial state on application start?
const initialState:CounterState = {
    current: 42,
};

export const reducer = createReducer(initialState);