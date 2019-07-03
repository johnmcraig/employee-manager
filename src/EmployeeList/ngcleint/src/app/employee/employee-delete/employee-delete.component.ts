import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/_interfaces/employee';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
import { Router, ActivatedRoute } from '@angular/router';
import * as $ from 'jquery';
// declare var $: any;

@Component({
  selector: 'app-employee-delete',
  templateUrl: './employee-delete.component.html',
  styleUrls: ['./employee-delete.component.css']
})
export class EmployeeDeleteComponent implements OnInit {

  public errorMessage = '';
  public employee: Employee;

  constructor(private repo: RepositoryService, private errorHandler: ErrorHandlerService,
              private router: Router, private activeRoute: ActivatedRoute) { }

  ngOnInit() {
    this.getEmployeeById();
  }

  public getEmployeeById() {
    const employeeId: string = this.activeRoute.snapshot.params.id;
    const employeeByIdUrl = `employees/${employeeId}`;

    this.repo.getData(employeeByIdUrl).subscribe(res => {
      this.employee = res as Employee;
    },
    (error) => {
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    });
  }

  public redirectToEmployeeList() {
    this.router.navigate(['/employee/list']);
  }

  public deleteEmployee() {
    const deleteUrl = `employees/${this.employee.id}`;
    this.repo.delete(deleteUrl).subscribe(res => {
      // $('#successModal').modal('show');
      //  document.getElementById('successModal').click();
      this.router.navigate(['employee/list']);
    },
    (error) => {
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    });
  }
}
