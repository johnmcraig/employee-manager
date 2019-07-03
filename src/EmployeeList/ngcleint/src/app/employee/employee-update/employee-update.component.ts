import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/_interfaces/employee';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
// import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-employee-update',
  templateUrl: './employee-update.component.html',
  styleUrls: ['./employee-update.component.css']
})
export class EmployeeUpdateComponent implements OnInit {

  public errorMessage = '';
  public employee: Employee;
  public employeeForm: FormGroup;

  constructor(private repo: RepositoryService, private router: Router,
              private errorHandler: ErrorHandlerService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.employeeForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.maxLength(100)]),
      startDate: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required, Validators.maxLength(200)]),
      position: new FormControl('', [Validators.required, Validators.maxLength(60)])
    });

    this.getEmployeeById();
  }

  private getEmployeeById() {
    const employeeId = this.route.snapshot.params.id;
    const employeeByIdUrl = `employees/${employeeId}`;

    this.repo.getData(employeeByIdUrl).subscribe(res => {
      this.employee = res as Employee;
      this.employeeForm.patchValue(this.employee);
      // $('#startDate').val(this.datePipe.transform(this.employee.startDate, 'MM/dd/yyyy'));
    },
    (error) => {
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    });
  }

  public updateEmployee(employeeFormValue: any) {
    if (this.employeeForm.valid) {
      this.executeEmployeeUpdate(employeeFormValue);
    }
  }

  public executeEmployeeUpdate(employeeFormValue: any) {

    this.employee.name = employeeFormValue.name;
    this.employee.position = employeeFormValue.position;
    this.employee.startDate = employeeFormValue.startDate;
    this.employee.email = employeeFormValue.email;

    const apiUrl = `employees/${this.employee.id}`;
    this.repo.update(apiUrl, this.employee).subscribe(res => {
      this.router.navigate(['employee/list']);
    },
    (error) => {
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
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

  public redirectToEmployeeList() {
    this.router.navigate(['/employee/list']);
  }

}
