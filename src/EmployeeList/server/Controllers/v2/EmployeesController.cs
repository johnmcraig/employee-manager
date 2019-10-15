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

                if(employees == null) return NotFound ();

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

                if(employee == null) return NotFound();

                return Mapper.Map<EmployeeDto>(employee);
            } 
            catch(Exception ex)
            {
                return StatusCode(500, $"Eternal server error: {ex}");
            }
        }

        [HttpPost(Name = nameof(AddEmployee))]
        public async Task<ActionResult<EmployeeCreateDto>> AddEmployee([FromBody] EmployeeCreateDto employeeCreate)
        {
            try
            {
                var employee = Mapper.Map<Employee>(employeeCreate);

                _repo.Add(employee);

                if(await _repo.SaveAllAsync())
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

        [HttpPut("{id}", Name = nameof(UpdateEmployee))]
        public async Task<ActionResult<EmployeeUpdateDto>> UpdateEmployee([FromRoute] Guid id, [FromBody] EmployeeUpdateDto employeeToUpdate)
        {
            try
            {
                if(employeeToUpdate == null) return BadRequest();

                var existingEmployee = _repo.GetEmployeeAsync(id);

                if(existingEmployee == null) return NotFound();

                await Mapper.Map(employeeToUpdate, existingEmployee);

               if(await _repo.SaveAllAsync())
               {
                   return Ok(Mapper.Map<EmployeeUpdateDto>(existingEmployee));
               }
               else
               {
                   return BadRequest("Could not save changes");
               }
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Enternal server error: {ex}");
            }
        }

        [HttpDelete("{id}", Name = nameof(DeleteEmployee))]
        public async Task<ActionResult> DeleteEmployee(Guid id) 
        {
            // try
            // {  
                var employee = await _repo.GetEmployeeAsync(id);

                if(employee == null) return NotFound();
                
                _repo.Delete(employee);
                
                if(await _repo.SaveAllAsync())
                {
                    return Ok();
                }
            // }
            // catch (Exception ex)
            // {
            //     return StatusCode(500, $"Eternal server error: {ex}");
            // }
            
            return BadRequest();
        }
    }
}