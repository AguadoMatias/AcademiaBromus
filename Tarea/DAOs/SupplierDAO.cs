using Microsoft.EntityFrameworkCore;
using Tarea.DAOs;
using Tarea.Data;

namespace Tarea.DAOs
{
    public class SupplierDAO : ISupplierDAO
    {
        private readonly NorthwindContext _context;

        public SupplierDAO(NorthwindContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Supplier>> GetSuppliers()
        {
            var suppliers = await _context.Suppliers.ToListAsync();

            return suppliers;
        }

        public async Task<Supplier?> GetSupplier(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);

            return supplier;
        }

        public async Task<Supplier>? PutSupplier(int id, Supplier supplier)
        {
            _context.Entry(supplier).State = EntityState.Modified;
            
            if(SupplierExists(id)) 
            {
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException s)
                {
                    Console.WriteLine(value: s.Message);
                }
            }
            return supplier;
        }

        public async Task<List<Supplier>> PostSupplier(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
            return await _context.Suppliers.ToListAsync();
        }

        public async Task<Supplier?> DeleteSupplier(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null || _context.Suppliers == null)
            {
                return null;
            }
            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();

            return supplier;
        }

        private bool SupplierExists(int id)
        {
            return _context.Suppliers.Any(e => e.SupplierId == id);
        }
    }
}
