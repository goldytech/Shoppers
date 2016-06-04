namespace Shoppers.Core.DataAccess
{
    using DomainModel.ProductPrice;

    using Microsoft.EntityFrameworkCore;

    public class PriceDataContext : BoundContext<PriceDataContext>
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Price>().HasKey(p => p.Id);

            modelBuilder.Entity<Price>()
                .HasOne(p => p.Product)
                .WithMany(p => p.ProductPrices)
                .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<Price>().Property(p => p.TimeStamp).IsConcurrencyToken();
        }
    }
}