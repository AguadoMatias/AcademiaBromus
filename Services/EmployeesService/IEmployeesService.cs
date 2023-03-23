using AcademiaBromus.Models;

namespace AcademiaBromus.Services.Employees
{
    public interface IEmployeesService
    {
        // READ
        public Task<IEnumerable<Employee>> ReadEmployees();

        // READ(id)
        public Task<Employee?> ReadEmployee(int id);

        // UPDATE
        public Task<Employee?> UpdateEmployee(int id, Employee employee);

        // CREATE
        public Task<Employee?> CreateEmployee(Employee employee);

        // DELETE
        public Task<Employee?> DeleteEmployee(int id);

    }
}
