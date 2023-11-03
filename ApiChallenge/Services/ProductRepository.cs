using ApiChallenge.DBContext;
using ApiChallenge.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ApiChallenge.Services
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly AppDbContext _context;

        public ProductoRepository(AppDbContext context)
        {
            _context = context;
        }



        public async Task<IEnumerable<Producto>> GetProductosAsync()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<Producto?> GetProductoByIdAsync(int id)
        {
            return await _context.Productos.FindAsync(id);
        }

        public async Task<Producto> CreateProductoAsync(Producto producto)
        {

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        public async Task UpdateProductoAsync(Producto producto)
        {
            
            
            _context.Entry(producto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductoAsync(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Producto>> GetProductosByDescripcionAsync(string descripcion)
        {
            return await _context.Productos
                .Where(p => p.Descripcion!.Contains(descripcion))
                .ToListAsync();
        }


    }

}
