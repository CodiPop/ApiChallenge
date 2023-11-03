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
    public class ProductosController : ControllerBase
    {
        private readonly ProductoService _service;

        public ProductosController(ProductoService service)
        {
            _service = service;
        }


        // GET: api/Productos
        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            var productos = await _service.GetProductosAsync();
            if (productos == null){
                return NotFound();
            }

            
            return Ok(productos);
        }

        // GET: api/Productos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {

            var producto = await _service.GetProductoByIdAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }


        [HttpGet("Desc")]
        public async Task<IActionResult> BuscarProductosPorDescripcion([FromQuery] string descripcion)
        {
            var productos = await _service.BuscarProductosPorDescripcion(descripcion);
            if (productos == null)
            {
                return NotFound();
            }
            return Ok(productos);
        }


        // PUT: api/Productos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, Producto producto)
        {
            if (id != producto.ProductoId)
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
                await _service.UpdateProductoAsync(id, currentProduct, producto);
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict("Se produjo un conflicto al intentar actualizar el producto. Puede que los datos hayan cambiado desde la última vez que se obtuvieron.");
            }
        }

        // POST: api/Productos
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            var newProducto = await _service.CreateProductoAsync(producto);
            if (newProducto == null)
            {
                return NotFound();
            }
            return Ok(newProducto);
        }

        // DELETE: api/Productos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var producto = await _service.GetProductoByIdAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            await _service.DeleteProductoAsync(id);
            return Ok();
        }

    }
}
