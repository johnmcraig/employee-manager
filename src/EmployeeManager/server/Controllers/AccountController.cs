using Microsoft.AspNetCore.Mvc;
using server.Data;

namespace server.Controllers
{
    public class AccountController : Controller 
    {
        private readonly EmployeeDbContext _dbContext;

        public AccountController(EmployeeDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            return View();
        }
    }
}