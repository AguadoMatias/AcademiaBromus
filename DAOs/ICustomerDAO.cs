using Microsoft.EntityFrameworkCore;

public interface ICustomerDAO
{
    public Task<IEnumerable<Customer>> GetCustomers();
    public Task<Customer?> GetCustomer(string id);
    public Task<Customer> SetCustomer(Customer customer);
    public Task<Customer>? UpdateCustomer(string id, Customer customer);
    public Task DeleteCustomer(string id);
}