using ApiChallenge.Models;

namespace ApiChallenge.Services
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetProductosAsync();
        Task<Producto?> GetProductoByIdAsync(int id);
        Task<IEnumerable<Producto>> GetProductosByDescripcionAsync(string descripcion);
        Task<Producto> CreateProductoAsync(Producto producto);
        Task UpdateProductoAsync(Producto producto);
        Task DeleteProductoAsync(int id);
       

  
    }

}