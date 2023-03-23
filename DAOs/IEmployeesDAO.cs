using AcademiaBromus.Models;

namespace AcademiaBromus.DAOs
{
    public interface IEmployeesDAO
    {
        // SELECT
        Task<IEnumerable<Employee>> SelectEmployees();

        // SELECT(ID)
        Task<Employee?> SelectEmployee(int id);

        // UPDATE
        Task<Employee?> UpdateEmployee(int id, Employee employee);

        // INSERT
        Task<Employee?> InsertEmployee(Employee employee);

        // DELETE
        Task<Employee?> DeleteEmployee(int id);
    }
}