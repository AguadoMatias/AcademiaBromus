using Tarea.Models;
using Microsoft.EntityFrameworkCore;
namespace Tarea.DAOs
{
    public interface ISupplierDAO
    {

        public Task<IEnumerable<Supplier>> SelectSuppliers();


        public Task<Supplier?> SelectSupplier(int id);


        public Task<Supplier>? UpdateSupplier(int id, Supplier supplier);


        public Task<List<Supplier>> InsertSupplier(Supplier supplier);


        public Task DeleteSupplier(int id);
    }
}




