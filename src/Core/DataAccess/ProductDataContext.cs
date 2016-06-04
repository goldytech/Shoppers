namespace Shoppers.Core.DataAccess
{
    using DomainModel.ProductCatalog;

    using Microsoft.EntityFrameworkCore;

    public class ProductDataContext :BoundContext<ProductDataContext>
    {
        public DbSet<Product> Products { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired();

            modelBuilder.Entity<Product>().HasKey(p => p.Id);

            modelBuilder.Entity<Product>().Property(p => p.TimeStamp).IsConcurrencyToken();


        }
    }
}