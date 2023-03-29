using Microsoft.EntityFrameworkCore;

public interface IShipperDAO
{

    public Task<IEnumerable<Shipper>> SelectShippers();

    public Task<Shipper?> SelectShipper(int id);

    public Task<List<Shipper>?> UpdateShipper(int id, Shipper shipper);

    public Task<List<Shipper>> InsertShipper(Shipper shipper);

    public Task DeleteShipper(int id);
    
}