using Microsoft.EntityFrameworkCore;

public interface ICustomerDAO
{

    public Task<IEnumerable<Customer>> SelectCustomer();


    public Task<Customer?> SelectCustomer(string id);


    public Task<List<Customer>?> UpdateCustomer(string id, Customer customer);


    public Task<List<Customer>> InsertCustomer(Customer customer);


    public Task DeleteCustomer(string id);
}