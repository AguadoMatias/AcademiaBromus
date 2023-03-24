using Microsoft.AspNetCore.Mvc;

namespace AcademiaBromus.Services.CustomerService
{
    public interface ICustomerService
    {
        // QUE TIPO DE RETORNO USAR CUANDO UN METODO DEVUELVE NO CONTENT
        Task<IEnumerable<Customer>> ReadCustomer();
        Task<Customer> ReadCustomer(string id);
        Task<Customer> UpdateCustomer(string id, Customer customer);

        Task<Customer>CreateCustomer(Customer customer);

        Task DeleteCustomer(string id);



    }
}
