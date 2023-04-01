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

        public async Task<Employee?> PutEmployee(int id, Employee employee)
        {
            return await _employeesDAO.PutEmployee(id, employee);
        }

        public async Task<Employee?> PostEmployee(Employee employee)
        {
            return await _employeesDAO.PostEmployee(employee);
        }

        public async Task<Employee?> DeleteEmployee(int id)
        {
            return await _employeesDAO.DeleteEmployee(id);
        }
    }
}
