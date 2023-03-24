using Microsoft.EntityFrameworkCore;
using Tarea.Data;
using Tarea.Models;

namespace Tarea.DAOs
{
    public class ShipperDAO : IShipperDAO
    {
        // SOLO EL DAO SERA RESPONSABLE DE INTERMEDIAR CON EL CONTEXTO DE LA BASE DE DATOS PARA EJECUTAR LAS OPERACIONES CRUD
        // POR ESO SE GENERA ACA LA PROPIEDAD SOLO LECTURA DE NORTHWIND CONTEXT
        private readonly NorthwindContext _context;

        public ShipperDAO(NorthwindContext context)
        {
            _context = context;
        }
        //GET
        public async Task<IEnumerable<Shipper>> SelectShippers()
        {
            var shippers = await _context.Shippers.ToListAsync();
            return shippers;
        }
        //GET BY ID
        public async Task<Shipper?> SelectShipper(int id)
        {
            var shipper = await _context.Shippers.FindAsync(id);
            return shipper;
        }
        //UPDATE
        public async Task<List<Shipper>?> UpdateShipper(int id, Shipper shipper)
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
        //PUT
        public async Task<List<Shipper>> InsertShipper(Shipper shipper)
        {
            _context.Shippers.Add(shipper);
            await _context.SaveChangesAsync();
            return await _context.Shippers.ToListAsync();
        }
        //DELETE
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
