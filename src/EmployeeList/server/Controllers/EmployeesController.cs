using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Data.Entites;
using server.Models;

namespace server.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _repo;

        public EmployeesController (IEmployeeRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<EmployeeModel[]>> GetAll(bool includeEmail = false)
        {
            try
            {
                var employees = await _repo.GettAllEmployeesAsync();

                if(employees == null)
                    return NotFound ();

                return Mapper.Map<EmployeeModel[]>(employees);
            } 
            catch(Exception ex)
            {
                return StatusCode(500, $"Enternal sever error: {ex}");
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<EmployeeModel>> GetSingle(Guid id)
        {
            try
            {
                var employee = await _repo.GetEmployeeAsync(id);

                if(employee == null)
                    return NotFound();

                return Mapper.Map<EmployeeModel>(employee);
            } 
            catch(Exception ex)
            {
                return StatusCode(500, $"Eternal server error: {ex}");
            }
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Employee employee)
        {

        }

        [HttpDelete("{id}")]
        public void DeleteById(Guid id) 
        {

        }

        [HttpGet("search/")]
        public async Task<ActionResult<EmployeeModel[]>> SearchByName(string searchString, bool includEmail = false)
        {
            try
            {
                var employee = await _repo.GettAllEmployeesAsync();

                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Enternal server error: {ex}");
            }
        }
    }
}