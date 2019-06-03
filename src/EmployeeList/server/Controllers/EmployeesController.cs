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
        private readonly EmployeeDbContext _dbContext;
        private readonly IMapper _mapper;
        public EmployeesController (EmployeeDbContext dbContext, IMapper mapper)
        {
            _mapper = mapper;
            _dbContext = dbContext;

            if(_dbContext.Employees.Count() == 0)
            {
                _dbContext.AddRange(new Employee
                {
                        Name = "Richard Hendricks",
                        Email = "contact@richardhendrinks.com"
                },
                new Employee
                {
                    Name = "Bertram Gilfoye",
                    Email = "contact@bertramgilfoye.com"
                },
                new Employee
                {
                    Name = "Denish Chugtai",
                    Email = "contact@denishchutai.com"
                });
                _dbContext.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var employees = await _dbContext.Employees.ToListAsync();

                EmployeeModel[] models = _mapper.Map<EmployeeModel[]>(employees);

                if(employees == null)
                    return NotFound ();

                return Ok(models);
            } 
            catch(Exception ex)
            {
                return StatusCode(500, $"Enternal sever error: {ex}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetSingle (Guid id)
        {
            try
            {
                var employee = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

                if(employee == null)
                    return NotFound();

                return Ok(employee);
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
    }
}