using Tarea.Models;
using Microsoft.EntityFrameworkCore;

namespace Tarea.DAOs
{
    public interface ISupplierDAO
    {
        public Task<IEnumerable<Supplier>> GetSuppliers();

        public Task<Supplier?> GetSupplier(int id);

        public Task<Supplier>? PutSupplier(int id, Supplier supplier);

        public Task<List<Supplier>> PostSupplier(Supplier supplier);

        public Task<Supplier?> DeleteSupplier(int id);
    }
}
