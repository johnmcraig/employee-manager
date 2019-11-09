using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Data.Entites;

namespace server.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeDbContext _dbContext;

        public EmployeesController(EmployeeDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        [HttpGet(Name = nameof(GetAll))]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAll()
        {
            try
            {
                return await _dbContext.Employees.ToListAsync();
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, $"Internal server Error: {ex}");
            }
        }

        [HttpGet("{id}", Name = nameof(GetEmployee))]
        public async Task<ActionResult<Employee>> GetEmployee(Guid id)
        {
            try
            {
                var employee = await _dbContext.Employees.FindAsync(id);
                if(employee == null)
                {
                    return BadRequest($"Could not find employee by id: {id}");
                }

                return employee;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server Error: {ex}");
            }
        }

        [HttpPost(Name = nameof(AddEmployee))]
        public async Task<ActionResult<Employee>> AddEmployee([FromBody] Employee employee) 
        { 
            try
            {
                if(!ModelState.IsValid) return BadRequest();
                
                _dbContext.Employees.Add(employee);
                await _dbContext.SaveChangesAsync();
                
                return CreatedAtRoute(nameof(GetEmployee), 
                    new { id = employee.Id }, employee);
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server Error: {ex}");
            }
        }

        [HttpPut("{id}", Name = nameof(UpdateEmployee))]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, [FromBody] Employee employee)
        {   
            if(!ModelState.IsValid) return BadRequest(ModelState);

            if(id != employee.Id) return BadRequest(); // return NotFound($"Could not find employee by id: {id}");
            
            _dbContext.Entry(employee).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) //(Exception ex)
            {
                if(!EmployeeExists(id))
                    return NotFound($"Could not find Employee by {id}");
                else
                    throw;

                // return StatusCode(500, $"Internal server Error: {ex}");
            }

            return NoContent();
        }

        [HttpDelete("{id}", Name = nameof(DeleteEmployee))]
        public async Task<IActionResult> DeleteEmployee(Guid id) 
        { 
            try
            {
                var employee = await _dbContext.Employees.FindAsync(id);

                if(employee == null)
                    return NotFound("Employee not found");

                _dbContext.Employees.Remove(employee);
                await _dbContext.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server Error: {ex}");
            }
        }

        private bool EmployeeExists(Guid id)
        {
            return _dbContext.Employees.Any(e => e.Id == id);
        }
    }
}