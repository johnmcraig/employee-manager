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
                    return CreatedAtAction(nameof(GetSingle), 
                        new { id = employee.Id },
                        Mapper.Map<EmployeeModel>(employee));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Enternal server error: {ex}");
            }

            return BadRequest();

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeModel>> Put(Guid id, [FromBody] EmployeeModel model)
        {
            try
            {
                var oldEmployee = _repo.GetEmployeeAsync(model.Id);

                if(model == null) 
                    return NotFound($"Could not find employee with {id}");

                await Mapper.Map(model, oldEmployee);

                if(await _repo.SaveChangesAsync())
                {
                    return Mapper.Map<EmployeeModel>(oldEmployee);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Enternal server error: {ex}");
            }

            return BadRequest();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) 
        {
            try
            {
                var employee = _repo.GetEmployeeAsync(id);

                if(employee == null)
                    return NotFound("Model not found");

                _repo.Delete(employee);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Eternal server error: {ex}");
            }
            
            return BadRequest("Employee could not be deleted");
        }

        [HttpGet("search")]
        public async Task<ActionResult<EmployeeModel>> SearchByName(string name, bool includEmail = false)
        {
            try
            {
                var employee = await _repo.GetByNameAsync(name);

                if(!employee.Any()) return NotFound();

                return Mapper.Map<EmployeeModel>(employee);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Enternal server error: {ex}");
            }
        }
    }
}