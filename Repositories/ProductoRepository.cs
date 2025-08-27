using Microsoft.EntityFrameworkCore;
using TredaApi.Data;
using TredaApi.Entities;
using TredaApi.Interfaces;


namespace TredaApi.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly AppDbContext _context;
        public ProductoRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Producto>> GetAll() => await _context.Productos.ToListAsync();
        public async Task<Producto?> GetById(int id) => await _context.Productos.FindAsync(id);
        public async Task Add(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Producto producto)
        {
            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var prod = await GetById(id);
            if (prod != null)
            {
                _context.Productos.Remove(prod);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Producto>> Search(string? nombre = null, decimal? precioMin = null, decimal? precioMax = null)
        {
            var query = _context.Productos.AsQueryable();

            if (!string.IsNullOrEmpty(nombre))
                query = query.Where(p => p.Nombre.Contains(nombre));

            if (precioMin.HasValue)
                query = query.Where(p => p.Precio >= precioMin.Value);

            if (precioMax.HasValue)
                query = query.Where(p => p.Precio <= precioMax.Value);

            return await query.ToListAsync();
        }

    }
}
