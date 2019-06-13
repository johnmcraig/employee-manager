using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
//using server.Models;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OperationsController : ControllerBase
    {
        private readonly IConfiguration _config;

        public OperationsController(IConfiguration config)
        {
            _config = config;
        }

        [HttpOptions("reloadconfig")]
        public IActionResult ReloadConfig()
        {
            try
            {
               var root = (IConfigurationRoot)_config;
               root.Reload();
               return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Enternal server error: {ex}"); 
            }
        }

        
    }
}