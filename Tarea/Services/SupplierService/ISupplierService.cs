using Tarea.Models;
using Microsoft.AspNetCore.Mvc;

namespace Tarea.Services.SupplierService
{
    public interface ISupplierService
    {
        public Task<IEnumerable<Supplier>> GetSuppliers();

        public Task<Supplier> GetSupplier(int id);

        public Task<Supplier> PutSupplier(int id, Supplier supplier);

        public Task<List<Supplier>> PostSupplier(Supplier supplier);

        public Task <Supplier?> DeleteSupplier(int id);
    }
}
