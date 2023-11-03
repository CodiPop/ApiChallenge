using ApiChallenge.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiChallenge.Services
{
    public class TiposProductosService
    {

        private readonly ITiposProductosRepository _tiposProductosRepository;

        public TiposProductosService(ITiposProductosRepository tiposProductoRepository)
        {
            _tiposProductosRepository = tiposProductoRepository;
        }

        public async Task<IEnumerable<TiposProducto>> GetProductosAsync()
        {
            return await _tiposProductosRepository.GetTiposProductosAsync();
        }


        public async Task<TiposProducto?> GetProductoByIdAsync(int id)
        {

            var producto = await _tiposProductosRepository.GetTipoProductoByIdAsync(id);

            return producto;
        }


        public async Task UpdateProductoAsync(int id, TiposProducto currentProduct, TiposProducto Product)
        {
            // Actualiza el producto con los nuevos datos
            currentProduct.Nombre = Product.Nombre;

            await _tiposProductosRepository.UpdateTipoProductoAsync(currentProduct);
        }

        public async Task<ActionResult<TiposProducto>> CreateProductoAsync(TiposProducto producto)
        {
            var newProducto = await _tiposProductosRepository.CreateTipoProductoAsync(producto);
            return newProducto;
        }
        public async Task<ActionResult<TiposProducto>> DeleteProductoAsync(int id)
        {
            var producto = await _tiposProductosRepository.GetTipoProductoByIdAsync(id);



            await _tiposProductosRepository.DeleteTipoProductoAsync(id);
            return null;
        }
    }
}
