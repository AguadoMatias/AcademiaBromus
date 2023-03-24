using Microsoft.AspNetCore.Mvc;

namespace AcademiaBromus.Services.ShipperService
{
    public interface ICustomerService
    {
        // QUE TIPO DE RETORNO USAR CUANDO UN METODO DEVUELVE NO CONTENT
        Task<IEnumerable<Customer>> ReadCustomer();
        Task<Customer> ReadCustomer(string id);
        Task<List<Customer>> UpdateCustomer(string id, Customer customer);

        Task<List<Customer>> CreateCustomer(Customer customer);

        Task DeleteCustomer(string id);



    }
}
