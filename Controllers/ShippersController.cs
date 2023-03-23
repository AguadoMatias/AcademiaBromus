using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AcademiaBromus.Data;
using AcademiaBromus.Models;
using AcademiaBromus.Services.ShipperService;

namespace AcademiaBromus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippersController : ControllerBase
    {
        // Define una propiedad solo lectura de la dependencia IShipperService
        private readonly IShipperService _shipperService;

        // Inyecta la dependencia de IShipperService y se la asigna a la propiedad antes creada
        public ShippersController(IShipperService shipperService)
        {
            _shipperService = shipperService;
        }

        // GET: api/Shippers
        [HttpGet]
        public async Task<IActionResult> GetShippers()
        {
            var shippers = await _shipperService.ReadShippers();
            return Ok(shippers);
        }

        // GET: api/Shippers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShipper(int id)
        {
            var shipper = await _shipperService.ReadShipper(id);

            if (shipper == null)
            {
                return NotFound();
            }

            return Ok(shipper);
        }

        // PUT: api/Shippers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShipper(int id, Shipper shipper)
        {
            if (id != shipper.ShipperId)
            {
                return BadRequest();
            }
            var shippers = await _shipperService.UpdateShipper(id, shipper);           

            if (shippers == null)
            {
                return NoContent();
            }
            return Ok(shippers);

        }

        // POST: api/Shippers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostShipper(Shipper shipper)
        {
            var shippers = await _shipperService.CreateShipper(shipper);
            if (shippers == null)
            {
                return NoContent();
            }
            return Ok(shippers);
        }

        // DELETE: api/Shippers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipper(int id)
        {
            await _shipperService.DeleteShipper(id);            
            return NoContent();
            
        }

        
    }
}
