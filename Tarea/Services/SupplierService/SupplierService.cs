using Tarea.DAOs;
using Tarea.Models;
using Microsoft.AspNetCore.Mvc;

namespace Tarea.Services.SupplierService
{
    //IMPLEMENTACION
    public class SupplierService : ISupplierService

        //Inyeccion de dependencias
    {
        private readonly ISupplierDAO _isupplierDAO;

        public SupplierService(ISupplierDAO isupplierDAO)
        {
            _isupplierDAO = isupplierDAO;
        }

        async Task<Supplier> ISupplierService.ReadSupplier(int id)
        {
            return await _isupplierDAO.SelectSupplier(id);
        }

        async Task<IEnumerable<Supplier>> ISupplierService.ReadSuppliers()
        {
            return await _isupplierDAO.SelectSuppliers();
        }

        async Task<List<Supplier>> ISupplierService.CreateSupplier(Supplier supplier)
        {
            return await _isupplierDAO.InsertSupplier(supplier);
        }

        async Task<Supplier> ISupplierService.UpdateSupplier(int id, Supplier supplier)
        {
            return await _isupplierDAO.UpdateSupplier(id, supplier);
        }

        Task ISupplierService.DeleteSupplier(int id)
        {
            return _isupplierDAO.DeleteSupplier(id);
        }
    }
}

