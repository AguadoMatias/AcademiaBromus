using Microsoft.EntityFrameworkCore;

public interface IShipperDAO
{

    public Task<IEnumerable<Shipper>> GetShippers();


    public Task<Shipper?> GetShipper(int id);


    public Task<List<Shipper>?> PutShipper(int id, Shipper shipper);


    public Task<List<Shipper>> PostShipper(Shipper shipper);


    public Task DeleteShipper(int id);
    
}