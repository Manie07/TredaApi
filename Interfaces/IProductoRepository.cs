using TredaApi.Entities;

namespace TredaApi.Interfaces
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetAll();
        Task<Producto?> GetById(int id);
        Task Add(Producto producto);
        Task Update(Producto producto);
        Task Delete(int id);
        Task<IEnumerable<Producto>> Search(string? nombre = null, decimal? precioMin = null, decimal? precioMax = null);

    }
}
