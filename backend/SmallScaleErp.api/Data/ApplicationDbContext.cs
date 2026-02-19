using Microsoft.EntityFrameworkCore;
using SmallScaleErp.api.Models;

namespace SmallScaleErp.api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<InventoryItem> InventoryItems { get; set; }
    }
}
