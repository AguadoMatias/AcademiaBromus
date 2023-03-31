using AcademiaBromus.Data;
using Microsoft.EntityFrameworkCore;

namespace AcademiaBromus.DAOs
{
    public class CustomerDao : ICustomerDAO
    {
        private readonly NorthwindContext _context;
        public CustomerDao(NorthwindContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
            return customers;
        }
        public async Task<Customer?> GetCustomer(string id)
        {
            var customer = await _context.Customers.FindAsync(id);
            return customer;
        }
        public async Task<Customer> SetCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
        public async Task<Customer>? UpdateCustomer(string id, Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            if (!CustomerExists(id)){
                try
                {
                    await _context.SaveChangesAsync();
                } 
                catch (DbUpdateConcurrencyException e)
                {
                    Console.WriteLine(value: e.Message);
                }
            }
            return customer;
        }
        public async Task DeleteCustomer(string id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }

        }

        private bool CustomerExists(string id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }
    }
}
