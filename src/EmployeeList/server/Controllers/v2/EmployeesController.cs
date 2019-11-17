using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using server.Data;
using server.Data.Entites;
using server.Dtos;

namespace server.Controllers.v2
{
    [ApiVersion("2.0")]
    [Route ("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _repo;
        
        public EmployeesController(IEmployeeRepository repo)
        {
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
                return StatusCode(500, $"Internal sever error: {ex}");
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
                return StatusCode(500, $"Internal server error: {ex}");
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
                return StatusCode(500, $"Internal server error: {ex}");
            }
            
            return BadRequest();
        }

        [HttpPut("{id}", Name = nameof(UpdateEmployee))]
        public async Task<ActionResult> UpdateEmployee([FromRoute] Guid id, [FromBody] EmployeeUpdateDto employeeToUpdate)
        {
            try 
            {
                var employeeFromRepo = await _repo.GetEmployeeAsync(id);

                if (employeeFromRepo == null) return NotFound();

                Mapper.Map(employeeToUpdate, employeeFromRepo);

                if(employeeToUpdate == null) return BadRequest();

                if(await _repo.SaveAllAsync())
                {
                    return Ok(Mapper.Map<EmployeeUpdateDto>(employeeFromRepo));
                }
                else
                {
                    return BadRequest("Could not save changes");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
                // throw new Exception($"Update employee with {id} failed to save");
            }
        }

        [HttpDelete("{id}", Name = nameof(DeleteEmployee))]
        public async Task<ActionResult> DeleteEmployee(Guid id) 
        {
            try
            {  
                var employee = await _repo.GetEmployeeAsync(id);

                if(employee == null) return NotFound();
                
                _repo.Delete(employee);
                
                if(await _repo.SaveAllAsync())
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
            
            return BadRequest();
        }
    }
}