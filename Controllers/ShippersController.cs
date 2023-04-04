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
        
        private readonly IShipperService _shipperService;

        
        public ShippersController(IShipperService shipperService)
        {
            _shipperService = shipperService;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetShippers()
        {
            try
            {
                var shippers = await _shipperService.GetShippers();
                return Ok(shippers);
            }
            catch (Exception e)
            {
                string message = e.Message;
                return BadRequest(message);

            }
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShipper(int id)
        {            
            try
            {
                var shipper = await _shipperService.GetShipper(id);
                if (shipper == null)
                {
                    return NotFound();
                }
                return Ok(shipper);
            }
            catch (Exception e)
            {
                string message = e.Message;
                return BadRequest(message);

            }
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShipper(int id, Shipper shipper)
        {
            if (id != shipper.ShipperId)
            {
                return BadRequest();
            }
            try
            {
                var shippers = await _shipperService.PutShipper(id, shipper);
                if (shippers == null)
                {
                    return NoContent();
                }
                return Ok(shippers);
            }
            catch (Exception e)
            {
                string message = e.Message;
                return BadRequest(message);

            }

        }

        
        [HttpPost]
        public async Task<IActionResult> PostShipper(Shipper shipper)
        {
            try
            {
                var shippers = await _shipperService.PostShipper(shipper);
                if (shippers == null)
                {
                    return NoContent();
                }
                return Ok(shippers);
            }
            catch (Exception e)
            {
                string message = e.Message;
                return BadRequest(message);

            }

        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipper(int id)
        {
            try
            {
                var shippers = await _shipperService.DeleteShipper(id);
                return Ok(shippers);
            }
            catch (Exception e)
            {
                string message = e.Message;
                return BadRequest(message);

            }
        }

        
    }
}
