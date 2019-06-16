using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using server.Data.Entites;

namespace server.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _dbContex;
        private readonly ILogger<EmployeeRepository> _logger;

        public EmployeeRepository(EmployeeDbContext dbContext, ILogger<EmployeeRepository> logger)
        {
            _dbContex = dbContext;
            _logger = logger;
        }

        public void Add<T>(T entity) where T : class
        {
            _logger.LogInformation($"Adding an object of type {entity.GetType()} to the context.");

            _dbContex.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _logger.LogInformation($"Removing an object of type {entity.GetType()} to the context.");

            _dbContex.Remove(entity);
        }

        public async Task<Employee> GetEmployeeAsync(Guid id)
        {
            _logger.LogInformation($"Getting a single employee by {id}");

            IQueryable<Employee> query = _dbContex.Employees;

            query = query.Where(e => e.Id == id);

            // var employee = await _dbContex.Employees.FirstOrDefaultAsync(x => x.Name == name);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Employee[]> GetAllEmployeesAsync()
        {
            _logger.LogInformation($"Getting all employees");

            var employees = await _dbContex.Employees.OrderByDescending(e => e.Name).ToArrayAsync();
                
            return employees;
        }

        public async Task<Employee[]> GetByNameAsync(string name)
        {
            _logger.LogInformation($"Attempting to search for name");

            IQueryable<Employee> query = _dbContex.Employees;

            query = query.OrderByDescending(e => e.Name);

            return await query.ToArrayAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            _logger.LogInformation($"Attempting to save changesd to the context.");

            return (await _dbContex.SaveChangesAsync()) > 0;
        }
    }
}