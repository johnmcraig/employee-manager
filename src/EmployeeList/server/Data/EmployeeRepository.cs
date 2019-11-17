using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using server.Data.Entities;

namespace server.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _dbContext;
        private readonly ILogger<EmployeeRepository> _logger;

        public EmployeeRepository(EmployeeDbContext dbContext, ILogger<EmployeeRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public void Add<T>(T entity) where T : class
        {
            _logger.LogInformation($"Adding an object of type {entity.GetType()} to the context.");

            _dbContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _logger.LogInformation($"Removing an object of type {entity.GetType()} to the context.");

            _dbContext.Remove(entity);
        }


        public async Task<Employee> GetEmployeeAsync(Guid id)
        {
            _logger.LogInformation($"Getting a single employee by {id}");

            IQueryable<Employee> query = _dbContext.Employees.Where(e => e.Id == id);

            // var employee = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Name == name);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Employee[]> GetAllEmployeesAsync()
        {
            _logger.LogInformation("Getting all employees");

            var employees = await _dbContext.Employees.OrderByDescending(e => e.Name).ToArrayAsync();
                
            return employees;
        }

        public async Task<bool> SaveAllAsync()
        {
            // _logger.LogInformation($"Attempting to save changed to the context.");
            // return (await _dbContext.SaveChangesAsync() > 0);
            try
            {
                _logger.LogInformation("Attempting to save changes to the context.");
                return await _dbContext.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to save changes: {ex}");
                return false;
            }
        }
    }
}