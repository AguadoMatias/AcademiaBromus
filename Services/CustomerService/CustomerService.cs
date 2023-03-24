using AcademiaBromus.DAOs;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaBromus.Services.ShipperService
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerDAO _icustomerDAO;

        // LA CLASE SHIPPERSERVICE INYECTA LA DEPENDENCIA DE LA INTERFACE iDAO MEDIANTE EL USO DE UNA PROPIEDAD;
        public CustomerService(ICustomerDAO icustomerDAO)
        {
            _icustomerDAO = icustomerDAO;
        }

        Task ICustomerService.DeleteCustomer(string id)
        {
            return _icustomerDAO.DeleteCustomer(id);
        }

        async Task<Customer> ICustomerService.ReadCustomer(string id)
        {
            return await _icustomerDAO.SelectCustomer(id);
        }

        async Task<IEnumerable<Customer>> ICustomerService.ReadCustomer()
        {
            return await _icustomerDAO.SelectCustomer();
        }

        async Task<List<Customer>> ICustomerService.CreateCustomer(Customer customer)
        {
            return await _icustomerDAO.InsertCustomer(customer);
        }

        async Task<List<Customer>> ICustomerService.UpdateCustomer(string id, Customer customer)
        {
            return await _icustomerDAO.UpdateCustomer(id, customer);
        }
    }
}
