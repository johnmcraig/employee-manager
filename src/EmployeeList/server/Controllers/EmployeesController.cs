using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
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
        private readonly LinkGenerator _linkGenerator;

        public EmployeesController(IEmployeeRepository repo, LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<EmployeeModel[]>> GetAll()
        {
            try
            {
                var employees = await _repo.GetAllEmployeesAsync();

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
        public async Task<ActionResult<EmployeeModel>> Post([FromBody] EmployeeModel model)
        {
            try
            {
                var employee = Mapper.Map<Employee>(model);

                _repo.Add(employee);

                if(await _repo.SaveChangesAsync())
                {
                    return CreatedAtAction(nameof(GetSingle), new { id = employee.Id }, Mapper.Map<EmployeeModel>(employee));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"{ex}");
            }

            return BadRequest();

        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] Employee employee)
        {

        }

        [HttpDelete("{id}")]
        public void DeleteById(Guid id) 
        {

        }

        [HttpGet("search")]
        public async Task<ActionResult<EmployeeModel[]>> SearchByName(string name, bool includEmail = false)
        {
            try
            {
                var employee = await _repo.GetByNameAsync(name);

                if(!employee.Any()) return NotFound();

                return Mapper.Map<EmployeeModel[]>(employee);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Enternal server error: {ex}");
            }
        }
    }
}