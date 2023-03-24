using AcademiaBromus.Data;
using Microsoft.EntityFrameworkCore;

namespace AcademiaBromus.DAOs
{
    public class ShipperDAO: IShipperDAO
    {
        // SOLO EL DAO SERA RESPONSABLE DE INTERMEDIAR CON EL CONTEXTO DE LA BASE DE DATOS PARA EJECUTAR LAS OPERACIONES CRUD
        // POR ESO SE GENERA ACA LA PROPIEDAD SOLO LECTURA DE NORTHWIND CONTEXT
        private readonly NorthwindContext _context;

        public ShipperDAO(NorthwindContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> SelectShippers()
        {
            var shippers = await _context.Shippers.ToListAsync();
            return shippers;
        }

        public async Task<Customer?> SelectShipper(int id)
        {
            var shipper = await _context.Shippers.FindAsync(id);          
            return shipper;
        }

        public async Task<List<Customer>?> UpdateShipper(int id, Customer shipper)
        {
            _context.Entry(shipper).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShipperExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return await _context.Shippers.ToListAsync();
        }

        public async Task<List<Customer>> InsertShipper(Customer shipper)
        {
            _context.Shippers.Add(shipper);
            await _context.SaveChangesAsync();
            return await _context.Shippers.ToListAsync();
        }

        public async Task DeleteShipper(int id)
        {
            var shipper = await _context.Shippers.FindAsync(id);
            if (shipper != null)
            {
                _context.Shippers.Remove(shipper);
                await _context.SaveChangesAsync();
            }
            
        }

        private bool ShipperExists(int id)
        {
            return _context.Shippers.Any(e => e.ShipperId == id);
        }
    }
}
