using Microsoft.AspNetCore.Mvc;

namespace server.Controllers
{
    public class RootController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}