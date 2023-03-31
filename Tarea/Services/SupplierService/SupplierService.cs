using Tarea.DAOs;
using Tarea.Models;
using Microsoft.AspNetCore.Mvc;

namespace Tarea.Services.SupplierService
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierDAO _isupplierDAO;

        public SupplierService(ISupplierDAO isupplierDAO)
        {
            _isupplierDAO = isupplierDAO;
        }

        async Task<Supplier> ISupplierService.GetSupplier(int id)
        {
            return await _isupplierDAO.GetSupplier(id);
        }

        async Task<IEnumerable<Supplier>> ISupplierService.GetSuppliers()
        {
            return await _isupplierDAO.GetSuppliers();
        }

        async Task<List<Supplier>> ISupplierService.PostSupplier(Supplier supplier)
        {
            return await _isupplierDAO.PostSupplier(supplier);
        }

        async Task<Supplier> ISupplierService.PutSupplier(int id, Supplier supplier)
        {
            return await _isupplierDAO.PutSupplier(id, supplier);
        }

        public async Task<Supplier?> DeleteSupplier(int id)
        {
            return await _isupplierDAO.DeleteSupplier(id);
        }
    }
}
