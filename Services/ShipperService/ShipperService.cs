using AcademiaBromus.DAOs;
using Microsoft.AspNetCore.Mvc;

namespace AcademiaBromus.Services.ShipperService
{
    public class ShipperService : IShipperService
    {
        private readonly IShipperDAO _iShipperDAO;

        public ShipperService(IShipperDAO iShipperDAO)
        {
            _iShipperDAO = iShipperDAO;
        }

        Task<List<Shipper>> IShipperService.DeleteShipper(int id)
        {            
            return _iShipperDAO.DeleteShipper(id);
        }

        async Task<Shipper> IShipperService.GetShipper(int id)
        {
            return await _iShipperDAO.GetShipper(id);
        }

        async Task<IEnumerable<Shipper>> IShipperService.GetShippers()
        {
            return await _iShipperDAO.GetShippers();
        }

        async Task<List<Shipper>> IShipperService.PostShipper(Shipper shipper)
        {
            return await _iShipperDAO.PostShipper(shipper);
        }

        async Task<List<Shipper>> IShipperService.PutShipper(int id, Shipper shipper)
        {
            return await _iShipperDAO.PutShipper(id, shipper);
        }
    }
}
