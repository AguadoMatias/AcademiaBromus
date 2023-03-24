using AcademiaBromus.Models;
using AcademiaBromus.Services.Employees;
using Microsoft.AspNetCore.Mvc;

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

        // GET: api/Employees
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _employeeService.ReadEmployees();
            if (employees == null)
            {
                return NotFound();
            }
            return Ok(employees);
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _employeeService.ReadEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            var updatedEmployee = await _employeeService.UpdateEmployee(id, employee);

            if (updatedEmployee == null)
            {
                return NotFound();
            }
            return Ok();
        }

        // POST: api/Employees
        [HttpPost]
        public async Task<IActionResult> PostEmployee(Employee employee)
        {
            var newEmployee = await _employeeService.CreateEmployee(employee);
            if (newEmployee == null)
            {
                return BadRequest();
            }
            return Ok();
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var deletedEmployee = await _employeeService.DeleteEmployee(id);
            if (deletedEmployee == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
