using Microsoft.EntityFrameworkCore;
using TredaApi.Entities;

namespace TredaApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Producto> Productos { get; set; }
    }
}
