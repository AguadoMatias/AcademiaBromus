using AcademiaBromus.Models;

namespace AcademiaBromus.Services.Employees
{
    public interface IEmployeesService
    {
        // READ
        public Task<IEnumerable<Employee>> GetEmployees();

        // READ(id)
        public Task<Employee?> GetEmployee(int id);

        // UPDATE
        public Task<Employee?> SetEmployee(int id, Employee employee);

        // CREATE
        public Task<Employee?> CreateEmployee(Employee employee);

        // DELETE
        public Task<Employee?> DeleteEmployee(int id);

    }
}
