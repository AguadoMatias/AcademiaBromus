using AcademiaBromus.Data;
using Microsoft.EntityFrameworkCore;

namespace AcademiaBromus.DAOs
{
    public class CustomerDao : ICustomerDAO
    {
        // SOLO EL DAO SERA RESPONSABLE DE INTERMEDIAR CON EL CONTEXTO DE LA BASE DE DATOS PARA EJECUTAR LAS OPERACIONES CRUD
        // POR ESO SE GENERA ACA LA PROPIEDAD SOLO LECTURA DE NORTHWIND CONTEXT
        private readonly NorthwindContext _context;

        public CustomerDao(NorthwindContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> SelectCustomer()
        {
            var customers = await _context.Customers.ToListAsync();
            return customers;
        }

        public async Task<Customer?> SelectCustomer(string id)
        {
            var customer = await _context.Customers.FindAsync(id);
            return customer;
        }

        public async Task<Customer>? UpdateCustomer(string id, Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return customer;
        }

        public async Task<Customer> InsertCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
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
