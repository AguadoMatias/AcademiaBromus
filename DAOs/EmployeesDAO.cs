using AcademiaBromus.Data;
using AcademiaBromus.Models;
using Microsoft.EntityFrameworkCore;

namespace AcademiaBromus.DAOs
{
    public class EmployeesDAO : IEmployeesDAO
    {
        private readonly NorthwindContext _context;

        private bool EmployeeExists(int id)
        {
            return (_context.Employees?.Any(e => e.EmployeeId == id)).GetValueOrDefault();
        }

        public EmployeesDAO(NorthwindContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee?> GetEmployee(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<Employee?> SetEmployee(int id, Employee employee)
        {
            if (EmployeeExists(id)) {
                _context.Entry(employee).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return employee;
            } else {
                return null;
            }          
        }

        public async Task<Employee?> CreateEmployee(Employee employee)
        {
            if (_context.Employees == null)
            {
                return null;
            }
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

        public async Task<Employee?> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (_context.Employees == null || employee == null)
            {
                return null;
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

    }
}
