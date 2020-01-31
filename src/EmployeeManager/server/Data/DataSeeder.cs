using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using server.Data.Entities;

namespace server.Data
{
    public class DataSeeder
    {   
        public static void SeedData(EmployeeDbContext dbContext)
        {   
            if(!dbContext.Employees.Any())
            {
                var employeeData = System.IO.File.ReadAllText("Data/EmployeeSeed.json");
                var employees = JsonConvert.DeserializeObject<List<Employee>>(employeeData);

                foreach (var employee in employees)
                {
                    dbContext.Employees.Add(employee);
                }
                
            }

            dbContext.SaveChanges();
        }
    }
}