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
using server.Dtos;
using server.Models;

namespace server.Controllers
{
    [ApiVersion("2.0")]
    [Route ("api/v{version:apiVersion}/[controller]")]
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
        public async Task<ActionResult<EmployeeDto[]>> GetAll()
        {
            try
            {
                var employees = await _repo.GetAllEmployeesAsync();

                if(employees == null)
                    return NotFound ();

                return Mapper.Map<EmployeeDto[]>(employees);
            } 
            catch(Exception ex)
            {
                return StatusCode(500, $"Enternal sever error: {ex}");
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployee(Guid id)
        {
            try
            {
                var employee = await _repo.GetEmployeeAsync(id);

                if(employee == null)
                    return NotFound();

                return Mapper.Map<EmployeeDto>(employee);
            } 
            catch(Exception ex)
            {
                return StatusCode(500, $"Eternal server error: {ex}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeCreateDto>> AddEmployee([FromBody] EmployeeCreateDto employeeCreate)
        {
            try
            {
                var employee = Mapper.Map<Employee>(employeeCreate);

                _repo.Add(employee);

                if(await _repo.SaveChangesAsync())
                {
                    return CreatedAtAction(nameof(GetEmployee), 
                        new { id = employee.Id },
                        Mapper.Map<EmployeeCreateDto>(employee));
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Enternal server error: {ex}");
            }

            return BadRequest();

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeUpdateDto>> Put(Guid id, EmployeeUpdateDto employeeToUpdate)
        {
            try
            {
                var oldEmployee = _repo.GetEmployeeAsync(id);

                if(employeeToUpdate == null) 
                    return NotFound($"Could not find employee with {id}");

                await Mapper.Map(employeeToUpdate, oldEmployee);

                if(await _repo.SaveChangesAsync())
                {
                    return Mapper.Map<EmployeeUpdateDto>(oldEmployee);
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
                // issue in repository with employeeCreate binding passing into method for Delete<T>(T entity)
                var oldEmployee = _repo.GetEmployeeAsync(id);

                if(oldEmployee == null) return NotFound();
                
                _repo.Delete(oldEmployee);
                
                if(await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Eternal server error: {ex}");
            }
            
            return BadRequest();
        }
    }
}