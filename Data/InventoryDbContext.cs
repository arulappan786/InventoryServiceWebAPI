using InventoryServiceWebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryServiceWebAPI.Data
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}
