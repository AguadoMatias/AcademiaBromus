using Tarea.Models;
using Microsoft.AspNetCore.Mvc;
namespace Tarea.Services.SupplierService
{
    public interface ISupplierService
    {
        Task<IEnumerable<Supplier>> ReadSuppliers();
        Task<Supplier> ReadSupplier(int id);
        Task<Supplier>UpdateSupplier(int id, Supplier supplier);

        Task<List<Supplier>> CreateSupplier(Supplier supplier);

        Task DeleteSupplier(int id);

    }
}


