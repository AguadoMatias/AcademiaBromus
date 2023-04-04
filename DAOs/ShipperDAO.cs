using AcademiaBromus.Data;
using Microsoft.EntityFrameworkCore;

namespace AcademiaBromus.DAOs
{
    public class ShipperDAO: IShipperDAO
    {
        
        private readonly NorthwindContext _context;

        public ShipperDAO(NorthwindContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Shipper>> GetShippers()
        {
            var shippers = await _context.Shippers.ToListAsync();
            return shippers;
        }

        public async Task<Shipper?> GetShipper(int id)
        {
            var shipper = await _context.Shippers.FindAsync(id);          
            return shipper;
        }

        public async Task<List<Shipper>?> PutShipper(int id, Shipper shipper)
        {
            if (ShipperExists(id))
            {
                _context.Entry(shipper).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {                    
                    throw;                    
                }
            }    

            return await _context.Shippers.ToListAsync();
        }

        public async Task<List<Shipper>> PostShipper(Shipper shipper)
        {
            _context.Shippers.Add(shipper);
            await _context.SaveChangesAsync();
            return await _context.Shippers.ToListAsync();
        }

        public async Task<List<Shipper?>> DeleteShipper(int id)
        {
            var shipper = await _context.Shippers.FindAsync(id);
            if (_context.Shippers != null && shipper != null)
            {
                _context.Shippers.Remove(shipper);
                await _context.SaveChangesAsync();
            }
            return await _context.Shippers.ToListAsync();
        }

        private bool ShipperExists(int id)
        {
            return _context.Shippers.Any(e => e.ShipperId == id);
        }
    }
}
