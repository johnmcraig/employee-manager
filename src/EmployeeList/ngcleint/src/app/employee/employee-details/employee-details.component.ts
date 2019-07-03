import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/_interfaces/employee';
import { Router, ActivatedRoute } from '@angular/router';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';

@Component({
  selector: 'app-employee-details',
  templateUrl: './employee-details.component.html',
  styleUrls: ['./employee-details.component.css']
})
export class EmployeeDetailsComponent implements OnInit {

  public employee: Employee;
  public errorMessage = '';

  constructor(private router: Router, private repo: RepositoryService,
              private route: ActivatedRoute, private errorHandler: ErrorHandlerService) { }

  ngOnInit() {
    this.getEmployeeDetails();
  }

  getEmployeeDetails() {
    const id: string = this.route.snapshot.params.id;
    const apiUrl = `employees/${id}`;

    this.repo.getData(apiUrl).subscribe(res => {
      this.employee = res as Employee;
    },
    (error) => {
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    });
  }

}
