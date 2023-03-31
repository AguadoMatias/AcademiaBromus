using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarea.Services.SupplierService;

namespace Tarea.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetSuppliers()
        {
            try
            {
                var suppliers = await _supplierService.GetSuppliers();
                if (suppliers == null)
                {
                    return NotFound();
                }
                return Ok(suppliers);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Supplier>> GetSupplier(int id)
        {
            try
            {
                var supplier = await _supplierService.GetSupplier(id);

                if (supplier == null)
                {
                    return NotFound();
                }
                return Ok(supplier);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupplier(int id, Supplier supplier)
        {
            try
            {
                if (id != supplier.SupplierId)
                {
                    return BadRequest();
                }
                var supplierPut = await _supplierService.PutSupplier(id, supplier);

                if (supplierPut == null)
                {
                    return NotFound();
                }
                return Ok(supplierPut);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Supplier>> PostSupplier(Supplier supplier)
        {
            try
            {
                var supplierPost = await _supplierService.PostSupplier(supplier);

                if (supplierPost == null)
                {
                    return BadRequest();
                }
                return StatusCode(201);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            try
            {
                var supplierDelete = await _supplierService.DeleteSupplier(id);

                if (supplierDelete == null)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
