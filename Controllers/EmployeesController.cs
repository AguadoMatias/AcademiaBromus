using AcademiaBromus.Models;
using AcademiaBromus.Services.Employees;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AcademiaBromus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesService _employeeService;

        public EmployeesController(IEmployeesService service)
        {
            _employeeService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var employees = await _employeeService.GetEmployees();
                if (employees == null)
                {
                    return NotFound();
                }
                return Ok(employees);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            try
            {
                var employee = await _employeeService.GetEmployee(id);
                if (employee == null)
                {
                    return NotFound();
                }
                return Ok(employee);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> SetEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }
            try
            {
                var updatedEmployee = await _employeeService.PutEmployee(id, employee);

                if (updatedEmployee == null)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Employee employee)
        {
            try
            {
                var newEmployee = await _employeeService.PostEmployee(employee);
                if (newEmployee == null)
                {
                    return BadRequest();
                }
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var deletedEmployee = await _employeeService.DeleteEmployee(id);
                if (deletedEmployee == null)
                {
                    return NotFound();
                }
                return NoContent();
            } 
            catch 
            {
                return StatusCode(500);
            }
        }
    }
}
