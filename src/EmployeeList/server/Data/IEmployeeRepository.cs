using System;
using System.Threading.Tasks;
using server.Data.Entities;

namespace server.Data
{
    public interface IEmployeeRepository
    {
         void Add<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;
         
         Task<bool> SaveAllAsync();

         Task<Employee[]> GetAllEmployeesAsync();
         Task<Employee> GetEmployeeAsync(Guid id);
    }
}