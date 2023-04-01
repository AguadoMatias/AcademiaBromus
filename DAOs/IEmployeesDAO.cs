using AcademiaBromus.Models;

namespace AcademiaBromus.DAOs
{
    public interface IEmployeesDAO
    {
        Task<IEnumerable<Employee>> GetEmployees();

        Task<Employee?> GetEmployee(int id);

        Task<Employee?> PutEmployee(int id, Employee employee);

        Task<Employee?> PostEmployee(Employee employee);

        Task<Employee?> DeleteEmployee(int id);
    }
}