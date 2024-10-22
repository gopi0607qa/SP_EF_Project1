using Microsoft.EntityFrameworkCore;

namespace SP_EF_Project1.Models
{
    public class DbContextClass : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DbContextClass(IConfiguration configuration) 
        {
            Configuration = configuration;

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductSales>().HasNoKey().ToView("ProductSales");
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<ProductSales> ProductSales { get; set; }
    }
}
