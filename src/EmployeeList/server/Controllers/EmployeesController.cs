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
        private readonly EmployeeDbContext _dbContext;

        public EmployeesController(IEmployeeRepository repo, EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
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
            catch(Exception ex)
            {
                return StatusCode(500, $"Enternal server error: {ex}");
            }

            return BadRequest();

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeModel>> Put(Guid id, Employee employee)
        {
            try
            {   
                if (id != employee.Id)
                {
                    return BadRequest();
                }

                _dbContext.Entry(employee).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();

                return NoContent();

                // var oldEmployee = _repo.GetEmployeeAsync(id);

                // if(model == null) 
                //     return NotFound($"Could not find employee with {id}");

                // await Mapper.Map(model, oldEmployee);

                // if(await _repo.SaveChangesAsync())
                // {
                //     return Mapper.Map<EmployeeModel>(oldEmployee);
                // }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Enternal server error: {ex}");
            }

            // return BadRequest();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) 
        {
            try
            {
                var employee = await _dbContext.Employees.FindAsync(id);

                if(employee == null) return NotFound("Employee not found");

                _dbContext.Employees.Remove(employee);
                await _dbContext.SaveChangesAsync();
                
                // issue in repository with model binding passing into method for Delete<T>(T entity)
                // var oldEmployee = _repo.GetEmployeeAsync(id);
                // if(oldEmployee == null) return NotFound();
                // _repo.Delete(oldEmployee);
                // if(await _repo.SaveChangesAsync())
                // {
                //     return Ok();
                // }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Eternal server error: {ex}");
            }
            
            //return BadRequest();
            return Ok();
        }
    }
}