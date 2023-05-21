using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Models
{
    public class BethanysPieShopDbContext: DbContext
    {
        public BethanysPieShopDbContext(DbContextOptions<BethanysPieShopDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Pie> Pies { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(string)))
            {
                property.SetColumnType("text");  // or "varchar"
            }

            // Other model configurations...
        }
    }

    

}
