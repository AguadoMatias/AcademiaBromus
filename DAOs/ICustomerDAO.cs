using Microsoft.EntityFrameworkCore;

public interface ICustomerDAO
{
    public Task<IEnumerable<Customer>> GetCustomers();
    public Task<Customer?> GetCustomer(string id);
    public Task<Customer> PostCustomer(Customer customer);
    public Task<Customer>? PutCustomer(string id, Customer customer);
    public Task DeleteCustomer(string id);
}