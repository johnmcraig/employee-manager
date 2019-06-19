using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Data.Entites;

namespace server.Data
{
    public class DataSeeder
    {
        private readonly EmployeeDbContext _dbContext;

        public DataSeeder(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task SeedData()
        {   
            await _dbContext.Database.EnsureCreatedAsync();

            if(_dbContext.Employees.Count() == 0)
            {
                SeedEmployees();
                await _dbContext.SaveChangesAsync();
            }
        }

        private void SeedEmployees()
        {
            var employees = new List<Employee>()
            {
                new Employee
                {
                   Id = Guid.NewGuid(),
                   Name = "Richard Hendricks",
                   Email = "contact@richardhendrinks.com",
                   Position = "Sales",
                   StartDate = DateTime.Now,
                   isCurrent = true
               },
               new Employee
               {
                   Id = Guid.NewGuid(),
                   Name = "Bertram Gilfoye",
                   Email = "contact@bertramgilfoye.com",
                   Position = "HR Manager",
                   StartDate = DateTime.Now,
                   isCurrent = true
               },
               new Employee
               {
                   Id = Guid.NewGuid(),
                   Name = "Denish Chugtai",
                   Email = "contact@denishchutai.com",
                   Position = "Data Analyst",
                   StartDate = DateTime.Now,
                   isCurrent = false
               }
            };

            _dbContext.Employees.AddRangeAsync(employees);
        }
    }
}