using AcademiaBromus.DAOs;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaBromus.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerDAO _icustomerDAO;

        public CustomerService(ICustomerDAO icustomerDAO)
        {
            _icustomerDAO = icustomerDAO;
        }
        
        Task ICustomerService.DeleteCustomer(string id)
        {
            return _icustomerDAO.DeleteCustomer(id);
        }

        async Task<Customer> ICustomerService.ReadCustomer(string id)
        {
            return await _icustomerDAO.SelectCustomer(id);
        }

        async Task<IEnumerable<Customer>> ICustomerService.ReadCustomer()
        {
            return await _icustomerDAO.SelectCustomer();
        }

        async Task<Customer> ICustomerService.CreateCustomer(Customer customer)
        {
            return await _icustomerDAO.InsertCustomer(customer);
        }

        async Task<Customer> ICustomerService.UpdateCustomer(string id, Customer customer)
        {
            return await _icustomerDAO.UpdateCustomer(id, customer);
        }
    }
}
