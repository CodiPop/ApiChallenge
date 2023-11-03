using ApiChallenge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiChallenge.Services
{
    public class ProductoService
    {

        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }


        public async Task<IEnumerable<Producto>> GetProductosAsync()
        {
            return await _productoRepository.GetProductosAsync();
        }

        
        public async Task<Producto?> GetProductoByIdAsync(int id)
        {

            var producto = await _productoRepository.GetProductoByIdAsync(id);

            return producto;
        }


        
        public async Task<List<Producto>> BuscarProductosPorDescripcion( string descripcion)
        {
            var result = await _productoRepository.GetProductosByDescripcionAsync(descripcion);
            return result.ToList();
        }


        // PUT: api/Productos/5

        public async Task UpdateProductoAsync(int id, Producto currentProduct, Producto Product)
        {
            // Actualiza el producto con los nuevos datos
            currentProduct.Descripcion = Product.Descripcion;
            currentProduct.TipoProductoId = Product.TipoProductoId;
            currentProduct.Valor = Product.Valor;
            currentProduct.FechaCompra = Product.FechaCompra;
            currentProduct.EstadoProducto = Product.EstadoProducto;
            

            await _productoRepository.UpdateProductoAsync(currentProduct);
        }

        // POST: api/Productos

        public async Task<ActionResult<Producto>> CreateProductoAsync(Producto producto)
        {
            var newProducto = await _productoRepository.CreateProductoAsync(producto);
            return newProducto;
        }

        // DELETE: api/Productos/5
        
        public async Task<ActionResult<Producto>> DeleteProductoAsync(int id)
        {
            var producto = await _productoRepository.GetProductoByIdAsync(id);

            

            await _productoRepository.DeleteProductoAsync(id);
            return null;
        }


    }
}
