using Tarea.Models;
using Microsoft.AspNetCore.Mvc;

namespace Tarea.Services.ShipperService
{
    public interface IShipperService
    {
        Task<IEnumerable<Shipper>> ReadShippers();
        Task<Shipper> ReadShipper(int id);
        Task<List<Shipper>> UpdateShipper(int id, Shipper shipper);

        Task<List<Shipper>> CreateShipper(Shipper shipper);

        Task DeleteShipper(int id);
    }
}
