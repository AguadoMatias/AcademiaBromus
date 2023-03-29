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

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _employeesDAO.GetEmployees();
        }

        public async Task<Employee?> GetEmployee(int id)
        {
            return await _employeesDAO.GetEmployee(id);
        }

        public async Task<Employee?> SetEmployee(int id, Employee employee)
        {
            return await _employeesDAO.SetEmployee(id, employee);
        }

        public async Task<Employee?> CreateEmployee(Employee employee)
        {
            return await _employeesDAO.CreateEmployee(employee);
        }

        public async Task<Employee?> DeleteEmployee(int id)
        {
            return await _employeesDAO.DeleteEmployee(id);
        }
    }
}
