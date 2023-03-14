import { createActionGroup, emptyProps, props } from "@ngrx/store";
import { ValidCountByValues } from "../../models";

export const counterEvents = createActionGroup({
    source: 'Counter',
    events: {
        'Increment Button Clicked': emptyProps(),
        'Decrement Button Clicked': emptyProps(),
        'Reset Clicked': emptyProps(),
        'Count By Set': props<{ by: ValidCountByValues }>(),
    }
})