using System.Threading.Tasks;
using server.Data.Entites;

namespace server.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public void Add<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public Task<Employee> GetEmployee(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task<Employee[]> GettAllEmployeesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}