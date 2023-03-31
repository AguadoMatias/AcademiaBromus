using AcademiaBromus.DAOs;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaBromus.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerDAO _iCustomerDAO;

        public CustomerService(ICustomerDAO icustomerDAO)
        {
            _iCustomerDAO = icustomerDAO;
        }

        async Task<Customer> ICustomerService.GetCustomer(string id)
        {
            return await _iCustomerDAO.GetCustomer(id);
        }
        async Task<IEnumerable<Customer>> ICustomerService.GetCustomers()
        {
            return await _iCustomerDAO.GetCustomers();
        }
        async Task<Customer> ICustomerService.SetCustomer(Customer customer)
        {
            return await _iCustomerDAO.SetCustomer(customer);
        }
        async Task<Customer> ICustomerService.UpdateCustomer(string id, Customer customer)
        {
            return await _iCustomerDAO.UpdateCustomer(id, customer);
        }
        Task ICustomerService.DeleteCustomer(string id)
        {
            return _iCustomerDAO.DeleteCustomer(id);
        }
    }
}
