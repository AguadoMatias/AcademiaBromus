using Microsoft.AspNetCore.Mvc;

namespace AcademiaBromus.Services.ShipperService
{
    public interface IShipperService
    {
        // QUE TIPO DE RETORNO USAR CUANDO UN METODO DEVUELVE NO CONTENT
        Task<IEnumerable<Customer>> ReadShippers();
        Task<Customer> ReadShipper(int id);
        Task<List<Customer>> UpdateShipper(int id, Customer shipper);

        Task<List<Customer>> CreateShipper(Customer shipper);

        Task DeleteShipper(int id);

        

    }
}
