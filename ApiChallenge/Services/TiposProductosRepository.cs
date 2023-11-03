using ApiChallenge.DBContext;
using ApiChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiChallenge.Services
{
    public class TiposProductosRepository : ITiposProductosRepository
    {

        private readonly AppDbContext _context;

        public TiposProductosRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<TiposProducto>> GetTiposProductosAsync()
        {
            return await _context.TiposProductos.ToListAsync();
        }

        public async Task<TiposProducto?> GetTipoProductoByIdAsync(int id)
        {
            return await _context.TiposProductos.FindAsync(id);
        }


        public async Task<TiposProducto> CreateTipoProductoAsync(TiposProducto tipoProducto)
        {
            _context.TiposProductos.Add(tipoProducto);
            await _context.SaveChangesAsync();
            return tipoProducto;
        }

        public async Task DeleteTipoProductoAsync(int id)
        {
            var tipoProducto = await _context.TiposProductos.FindAsync(id);
            if (tipoProducto != null)
            {
                _context.TiposProductos.Remove(tipoProducto);
                await _context.SaveChangesAsync();
                
            }
        }

        public async Task UpdateTipoProductoAsync(TiposProducto tipoProducto)
        {
            _context.Entry(tipoProducto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
