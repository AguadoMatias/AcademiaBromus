using AcademiaBromus.DAOs;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaBromus.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerDAO _iCustomerDAO;

        public CustomerService(ICustomerDAO iCustomerDAO)
        {
            _iCustomerDAO = iCustomerDAO;
        }

        async Task<Customer> ICustomerService.GetCustomer(string id)
        {
            return await _iCustomerDAO.GetCustomer(id);
        }
        async Task<IEnumerable<Customer>> ICustomerService.GetCustomers()
        {
            return await _iCustomerDAO.GetCustomers();
        }
        async Task<Customer> ICustomerService.PostCustomer(Customer customer)
        {
            return await _iCustomerDAO.PostCustomer(customer);
        }
        async Task<Customer> ICustomerService.PutCustomer(string id, Customer customer)
        {
            return await _iCustomerDAO.PutCustomer(id, customer);
        }
        Task ICustomerService.DeleteCustomer(string id)
        {
            return _iCustomerDAO.DeleteCustomer(id);
        }
    }
}
