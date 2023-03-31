using Microsoft.AspNetCore.Mvc;

namespace AcademiaBromus.Services.CustomerService
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetCustomer(string id);
        Task<Customer> SetCustomer(Customer customer);
        Task<Customer> UpdateCustomer(string id, Customer customer);
        Task DeleteCustomer(string id);



    }
}
