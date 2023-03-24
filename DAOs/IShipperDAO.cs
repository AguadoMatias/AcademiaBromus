using Microsoft.EntityFrameworkCore;

public interface IShipperDAO
{

    public Task<IEnumerable<Customer>> SelectShippers();


    public Task<Customer?> SelectShipper(int id);


    public Task<List<Customer>?> UpdateShipper(int id, Customer shipper);


    public Task<List<Customer>> InsertShipper(Customer shipper);


    public Task DeleteShipper(int id);
    
}