using Microsoft.AspNetCore.Mvc;

namespace AcademiaBromus.Services.ShipperService
{
    public interface IShipperService
    {
        Task<IEnumerable<Shipper>> GetShippers();


        Task<Shipper> GetShipper(int id);


        Task<List<Shipper>> PutShipper(int id, Shipper shipper);


        Task<List<Shipper>> PostShipper(Shipper shipper);


        Task DeleteShipper(int id);
    }
}
