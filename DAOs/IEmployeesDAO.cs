using AcademiaBromus.Models;

namespace AcademiaBromus.DAOs
{
    public interface IEmployeesDAO
    {
        Task<IEnumerable<Employee>> GetEmployees();

        Task<Employee?> GetEmployee(int id);

        Task<Employee?> SetEmployee(int id, Employee employee);

        Task<Employee?> CreateEmployee(Employee employee);

        Task<Employee?> DeleteEmployee(int id);
    }
}