namespace SharedServices.DataAccess
{
    using DomainModel.ProductCatalog;
    using DomainModel.ProductPrice;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The database context.
    /// </summary>
    public class AppDatabaseContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppDatabaseContext"/> class.
        /// </summary>
        /// <param name="dbcontextOptions">
        /// The db context options.
        /// </param>
        public AppDatabaseContext(DbContextOptions dbcontextOptions)
            : base(dbcontextOptions)
        {
        }

        public DbSet<Product> Products { get; set; } 

        public DbSet<Price>   ProductPrices { get; set; }
    }
}