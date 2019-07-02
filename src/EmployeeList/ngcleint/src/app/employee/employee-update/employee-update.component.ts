import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/_interfaces/employee';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-employee-update',
  templateUrl: './employee-update.component.html',
  styleUrls: ['./employee-update.component.css']
})
export class EmployeeUpdateComponent implements OnInit {
  public errorMessage = '';
  public employee: Employee;
  public employeeForm: FormGroup;

  constructor() { }

  ngOnInit() {
  }

  public redirectToEmployeeList() {

  }

}
