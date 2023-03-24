using Microsoft.AspNetCore.Mvc;

namespace AcademiaBromus.Services.ShipperService
{
    public interface IShipperService
    {
        // QUE TIPO DE RETORNO USAR CUANDO UN METODO DEVUELVE NO CONTENT
        Task<IEnumerable<Shipper>> ReadShippers();
        Task<Shipper> ReadShipper(int id);
        Task<List<Shipper>> UpdateShipper(int id, Shipper shipper);

        Task<List<Shipper>> CreateShipper(Shipper shipper);

        Task DeleteShipper(int id);

        

    }
}
