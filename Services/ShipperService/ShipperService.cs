using AcademiaBromus.DAOs;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaBromus.Services.ShipperService
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

        async Task<Customer> IShipperService.ReadShipper(int id)
        {
            return await _ishipperDAO.SelectShipper(id);
        }

        async Task<IEnumerable<Customer>> IShipperService.ReadShippers()
        {
            return await _ishipperDAO.SelectShippers();
        }

        async Task<List<Shipper>> IShipperService.CreateShipper(Shipper shipper)
        {
            return await _ishipperDAO.InsertShipper(shipper);
        }

        async Task<List<Customer>> IShipperService.UpdateShipper(int id, Shipper shipper)
        {
            return await _ishipperDAO.UpdateShipper(id, shipper);
        }
    }
}
