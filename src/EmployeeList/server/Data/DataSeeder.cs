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
                   Email = "contact@richardhendrinks.com"
               },
               new Employee
               {
                   Id = Guid.NewGuid(),
                   Name = "Bertram Gilfoye",
                   Email = "contact@bertramgilfoye.com"
               },
               new Employee
               {
                   Id = Guid.NewGuid(),
                   Name = "Denish Chugtai",
                   Email = "contact@denishchutai.com"
               }
            };

            _dbContext.Employees.AddRangeAsync(employees);
        }
    }
}