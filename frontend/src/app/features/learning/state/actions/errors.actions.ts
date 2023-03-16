import { createActionGroup, emptyProps, props } from "@ngrx/store";

export const errorsEvents = createActionGroup({
    source: '[Learning] errors Events',
    events: {
        'Error Happened': props<{message: string}>(),
        'Error Cleared': emptyProps()
    }
})