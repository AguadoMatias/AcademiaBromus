using AcademiaBromus.DAOs;

namespace AcademiaBromus.Services.Employees
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IEmployeesDAO _employeesDAO;

        public EmployeesService(IEmployeesDAO dao)
        {
            _employeesDAO = dao;
        }

        public async Task<IEnumerable<Employee>> ReadEmployees()
        {
            return await _employeesDAO.SelectEmployees();
        }

        public async Task<Employee?> ReadEmployee(int id)
        {
            return await _employeesDAO.SelectEmployee(id);
        }

        public async Task<Employee?> UpdateEmployee(int id, Employee employee)
        {
            return await _employeesDAO.UpdateEmployee(id, employee);
        }

        public async Task<Employee?> CreateEmployee(Employee employee)
        {
            return await _employeesDAO.InsertEmployee(employee);
        }

        public async Task<Employee?> DeleteEmployee(int id)
        {
            return await _employeesDAO.DeleteEmployee(id);
        }
    }
}
