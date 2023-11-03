using ApiChallenge.Models;

namespace ApiChallenge.Services
{
    public interface ITiposProductosRepository
    {

        Task<IEnumerable<TiposProducto>> GetTiposProductosAsync();

        Task<TiposProducto?> GetTipoProductoByIdAsync(int id);
        Task<TiposProducto> CreateTipoProductoAsync(TiposProducto tipoProducto);
        Task UpdateTipoProductoAsync(TiposProducto tipoProducto);
        Task DeleteTipoProductoAsync(int id);



    }
}
