using Microsoft.AspNetCore.Mvc;

namespace AcademiaBromus.Services.CustomerService
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetCustomer(string id);
        Task<Customer> PostCustomer(Customer customer);
        Task<Customer> PutCustomer(string id, Customer customer);
        Task DeleteCustomer(string id);



    }
}
