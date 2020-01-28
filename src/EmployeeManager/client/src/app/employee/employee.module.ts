import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { RouterModule } from '@angular/router';
import { EmployeeDetailsComponent } from './employee-details/employee-details.component';
import { SharedModule } from '../shared/shared.module';
import { EmployeeCreateComponent } from './employee-create/employee-create.component';
import { ReactiveFormsModule } from '@angular/forms';
import { EmployeeUpdateComponent } from './employee-update/employee-update.component';
import { EmployeeDeleteComponent } from './employee-delete/employee-delete.component';

@NgModule({
  declarations: [
    EmployeeListComponent,
    EmployeeDetailsComponent,
    EmployeeCreateComponent,
    EmployeeUpdateComponent,
    EmployeeDeleteComponent],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    RouterModule.forChild([
      { path: 'list', component: EmployeeListComponent },
      { path: 'details/:id', component: EmployeeDetailsComponent },
      { path: 'create', component: EmployeeCreateComponent },
      { path: 'update/:id', component: EmployeeUpdateComponent },
      { path: 'delete/:id', component: EmployeeDeleteComponent}
    ])
  ]
})
export class EmployeeModule { }
