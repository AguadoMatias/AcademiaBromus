using AcademiaBromus.Models;

namespace AcademiaBromus.Services.Employees
{
    public interface IEmployeesService
    {
        public Task<IEnumerable<Employee>> GetEmployees();

        public Task<Employee?> GetEmployee(int id);

        public Task<Employee?> PutEmployee(int id, Employee employee);

        public Task<Employee?> PostEmployee(Employee employee);

        public Task<Employee?> DeleteEmployee(int id);

    }
}
