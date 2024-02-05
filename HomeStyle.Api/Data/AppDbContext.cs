
using HomeStyler.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeStyler.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedData(ref modelBuilder);
        }

        private static void SeedData(ref ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<User>()
                .HasData(User.GetInitialUsers());

            modelBuilder.Entity<Category>()
                .HasData(Category.GetInitialData());

            modelBuilder.Entity<Offer>()
                .HasData(Offer.GetInitialData());

            modelBuilder.Entity<Product>()
                .HasData(Product.GetInitialData());
        }



    }
}
