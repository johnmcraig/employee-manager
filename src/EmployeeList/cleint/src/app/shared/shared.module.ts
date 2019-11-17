import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ErrorModalComponent } from './modals/error-modal/error-modal.component';
import { SuccessModalComponent } from './modals/success-modal/success-modal.component';
import { DatepickerDirective } from './directives/datepicker.directive';

@NgModule({
  declarations: [ErrorModalComponent, SuccessModalComponent, DatepickerDirective, SuccessModalComponent],
  imports: [
    CommonModule
  ],
  exports: [
    ErrorModalComponent, DatepickerDirective, SuccessModalComponent
  ]
})
export class SharedModule { }
