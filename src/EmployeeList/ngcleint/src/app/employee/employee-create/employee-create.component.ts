import { Component, OnInit } from '@angular/core';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { Router } from '@angular/router';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { EmployeeForCreating } from 'src/app/_interfaces/employee-create';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
// import * as $ from 'jquery';
// declare var $: any;

@Component({
  selector: 'app-employee-create',
  templateUrl: './employee-create.component.html',
  styleUrls: ['./employee-create.component.css']
})
export class EmployeeCreateComponent implements OnInit {
  public errorMessage = '';

  public employeeForm: FormGroup;

  constructor(private repo: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router) { }

  ngOnInit() {
    this.employeeForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.maxLength(60)]),
      startDate: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required, Validators.maxLength(100)]),
      position: new FormControl('', [Validators.required, Validators.maxLength(60)])
    });
  }

  public validateControl(controlName: string) {
    if (this.employeeForm.controls[controlName].invalid && this.employeeForm.controls[controlName].touched) {
      return true;
    }
    return false;
  }

  public hasError(controlName: string, errorName: string) {
    if (this.employeeForm.controls[controlName].hasError(errorName)) {
      return true;
    }
    return false;
  }

  public executeDatePicker(event: any) {
    this.employeeForm.patchValue({ startDate: event });
  }

  public createEmployee(employeeFormValue: any) {
    if (this.employeeForm.valid) {
      this.executeEmployeeCreation(employeeFormValue);
    }
  }

  private executeEmployeeCreation(employeeFormValue: { name: any; startDate: Date; email: any; position: any; }) {
    const employee: EmployeeForCreating = {
      name: employeeFormValue.name,
      position: employeeFormValue.position,
      startDate: employeeFormValue.startDate,
      email: employeeFormValue.email
    };

    const apiUrl = 'employees/';
    this.repo.create(apiUrl, employee)
      .subscribe(res => {
        // $('#successModal').modal('show');
        //  document.getElementById('successModal').click();
        this.router.navigate(['employee/list']);
      },
      (error => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
    );
  }

  public redirectToEmployeeList() {
    this.router.navigate(['/employee/list']);
  }
}
