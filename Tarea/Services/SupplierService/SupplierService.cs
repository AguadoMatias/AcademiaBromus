using Tarea.DAOs;
using Tarea.Models;
using Microsoft.AspNetCore.Mvc;

namespace Tarea.Services.SupplierService
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierDAO _iSupplierDAO;

        public SupplierService(ISupplierDAO iSupplierDAO)
        {
            _iSupplierDAO = iSupplierDAO;
        }

        async Task<Supplier> ISupplierService.GetSupplier(int id)
        {
            return await _iSupplierDAO.GetSupplier(id);
        }

        async Task<IEnumerable<Supplier>> ISupplierService.GetSuppliers()
        {
            return await _iSupplierDAO.GetSuppliers();
        }

        async Task<List<Supplier>> ISupplierService.PostSupplier(Supplier supplier)
        {
            return await _iSupplierDAO.PostSupplier(supplier);
        }

        async Task<Supplier> ISupplierService.PutSupplier(int id, Supplier supplier)
        {
            return await _iSupplierDAO.PutSupplier(id, supplier);
        }

        public async Task<Supplier?> DeleteSupplier(int id)
        {
            return await _iSupplierDAO.DeleteSupplier(id);
        }
    }
}
