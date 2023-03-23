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

        public async Task<IEnumerable<Employee>> SelectEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee?> SelectEmployee(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<Employee?> UpdateEmployee(int id, Employee employee)
        {

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return employee;
        }

        public async Task<Employee?> InsertEmployee(Employee employee)
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
            if (_context.Employees == null)
            {
                return null;
            }
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return null;
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return employee;
        }

    }
}
