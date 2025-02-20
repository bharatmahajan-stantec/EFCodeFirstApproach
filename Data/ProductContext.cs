using EFCodeFirst.EntityClasses;
using System.Data.Entity;

namespace EFCodeFirst.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("name=productContextConnectionString")
        {
            //Setting the Database Initializer as MigrateDatabaseToLatestVersion
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ProductContext, EFCodeFirst.Migrations.Configuration>());
        }
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;    
        public DbSet<OrderItem> OrderItems { get; set; } = null!;
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<OrderItem>()
                .HasRequired(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithRequired(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId)
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}
