import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CounterComponent } from './counter.component';
import { RouterModule, Routes } from '@angular/router';

@NgModule({
  declarations: [
    CounterComponent
  ],
  imports: [
    CommonModule,
  ],
  exports: [CounterComponent]
})
export class CounterModule { }
