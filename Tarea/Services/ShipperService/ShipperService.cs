using Tarea.DAOs;
using Tarea.Models;
using Microsoft.AspNetCore.Mvc;

namespace Tarea.Services.ShipperService
{
    public class ShipperService : IShipperService
    {
        private readonly IShipperDAO _ishipperDAO;

        // LA CLASE SHIPPERSERVICE INYECTA LA DEPENDENCIA DE LA INTERFACE iDAO MEDIANTE EL USO DE UNA PROPIEDAD;
        public ShipperService(IShipperDAO ishipperDAO)
        {
            _ishipperDAO = ishipperDAO;
        }

        Task IShipperService.DeleteShipper(int id)
        {
            return _ishipperDAO.DeleteShipper(id);
        }

        async Task<Shipper> IShipperService.ReadShipper(int id)
        {
            return await _ishipperDAO.SelectShipper(id);
        }

        async Task<IEnumerable<Shipper>> IShipperService.ReadShippers()
        {
            return await _ishipperDAO.SelectShippers();
        }

        async Task<List<Shipper>> IShipperService.CreateShipper(Shipper shipper)
        {
            return await _ishipperDAO.InsertShipper(shipper);
        }

        async Task<List<Shipper>> IShipperService.UpdateShipper(int id, Shipper shipper)
        {
            return await _ishipperDAO.UpdateShipper(id, shipper);
        }
    }
}
