import { Component, OnInit } from '@angular/core';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { Employee } from 'src/app/_interfaces/employee';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {

  public employees: Employee[];
  public errorMessage = '';

  constructor(private repo: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router) { }

  ngOnInit() {
    this.getAllEmployees();
  }

  public getAllEmployees() {
    const apiAddress = 'employees';
    this.repo.getData(apiAddress).subscribe(res => {
      this.employees = res as Employee[];
    },
    (error) => {
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    });
  }

  public getEmployeeDetails(id: any) {
    const detailsUrl = `employee/details/${id}`;
    this.router.navigate([detailsUrl]);
  }

  public redirectToDeletePage(id: any) {
    const deleteUrl = `employee/delete/${id}`;
    this.router.navigate([deleteUrl]);
  }

  public redirectToUpdatePage(id: any) {
    const updateUrl = `employee/update/${id}`;
    this.router.navigate([updateUrl]);
  }
}
