using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiChallenge.DBContext;
using ApiChallenge.Models;
using ApiChallenge.Services;

namespace ApiChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposProductosController : ControllerBase
    {
        private readonly TiposProductosService _service;

        public TiposProductosController(TiposProductosService service)
        {
            _service = service;
        }

        // GET: api/TiposProductos
        [HttpGet]
        public async Task<ActionResult<TiposProducto>> GetTiposProductos()
        {
            var productos = await _service.GetProductosAsync();
            if (productos == null)
            {
                return NotFound();
            }


            return Ok(productos);
        }

        // GET: api/TiposProductos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TiposProducto>> GetTiposProducto(int id)
        {

            var producto = await _service.GetProductoByIdAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }

        // PUT: api/TiposProductos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTiposProducto(int id, TiposProducto tiposProducto)
        {
            if (id != tiposProducto.TipoProductoId)
            {
                return BadRequest("El ID del producto en la URL no coincide con el ID del producto en el cuerpo de la solicitud.");
            }

            var currentProduct = await _service.GetProductoByIdAsync(id);

            if (currentProduct == null)
            {
                return NotFound();
            }

            try
            {
                await _service.UpdateProductoAsync(id, currentProduct, tiposProducto);
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict("Se produjo un conflicto al intentar actualizar el producto. Puede que los datos hayan cambiado desde la última vez que se obtuvieron.");
            }
        }

        // POST: api/TiposProductos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TiposProducto>> PostTiposProducto(TiposProducto tiposProducto)
        {
            var newProducto = await _service.CreateProductoAsync(tiposProducto);
            if (newProducto == null)
            {
                return NotFound();
            }
            return Ok(newProducto);
        }

        // DELETE: api/TiposProductos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTiposProducto(int id)
        {
            var producto = await _service.GetProductoByIdAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            await _service.DeleteProductoAsync(id);
            return Ok(); ;
        }


    }
}
