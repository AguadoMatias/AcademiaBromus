using Microsoft.EntityFrameworkCore;
using Tarea.DAOs;
using Tarea.Data;

namespace Tarea.DAOs
{
    public class SupplierDAO : ISupplierDAO 
    {
      
        private readonly NorthwindContext _context;

        //Constructor
        public SupplierDAO(NorthwindContext context)
        {
            _context = context;
        }
        //GET
        public async Task<IEnumerable<Supplier>> SelectSuppliers()
        {
            var suppliers = await _context.Suppliers.ToListAsync();
            return suppliers;
        }
        //GET BY ID
        public async Task<Supplier?> SelectSupplier(int id)
        {

            var supplier = await _context.Suppliers.FindAsync(id);
 
            return supplier;
        }
        //UPDATE
        public async Task<Supplier>? UpdateSupplier(int id, Supplier supplier)
        {
            _context.Entry(supplier).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return supplier;
        }
        //PUT
        public async Task<List<Supplier>> InsertSupplier(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
            return await _context.Suppliers.ToListAsync();
        }
        //DELETE
        public async Task DeleteSupplier(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier != null)
            {
                _context.Suppliers.Remove(supplier);
                await _context.SaveChangesAsync();
            }

        }

        private bool SupplierExists(int id)
        {
            return _context.Suppliers.Any(e => e.SupplierId == id);
        } }
}


