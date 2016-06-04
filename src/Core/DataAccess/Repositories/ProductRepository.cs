namespace Shoppers.Core.DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DomainModel.ProductCatalog;

    using Microsoft.EntityFrameworkCore;

    using Shoppers.Core.DataAccess.Contracts;

    public class ProductRepository :IProductRepository
    {
        private readonly ProductDataContext productDataContext;

        public ProductRepository(ProductDataContext productDataContext)
        {
            this.productDataContext = productDataContext;
           
        }

        public Task<Product> GetByIdAsync(Guid id) => this.productDataContext.Products.FirstOrDefaultAsync(p => p.Id.Equals(id));

        public Task<IQueryable<Product>> GetAllAsync()
        {
            return Task.Run(
                () => this.productDataContext.Products.AsQueryable());
        }

        public Task Insert(Product entity)
        {
            return Task.Run(
                () =>
                    {
                        this.productDataContext.Products.Add(entity);
                    });
        }

        public Task Update(Product entity)
        {
            return Task.Run(async () =>
            {
              
                    this.productDataContext.Products.Attach(entity);
                    this.productDataContext.Entry(entity).State = EntityState.Modified;
                await this.productDataContext.SaveChangesAsync().ConfigureAwait(false);
            });
        }

        public Task Delete(Guid id)
        {
            return Task.Run(
                async () =>
                    {
                        var producttobeDeleted =
                            await
                            this.productDataContext.Products.FirstOrDefaultAsync(p => p.Id.Equals(id))
                                .ConfigureAwait(false);
                        this.productDataContext.Products.Remove(producttobeDeleted);
                        await this.productDataContext.SaveChangesAsync().ConfigureAwait(false);
                    });
        }

        public Task<List<Product>> FindProductsByCategoryAsync(ProductCategory productCategory)
        {
            return
                this.productDataContext.Products.Where(p => p.ProductCategory.Equals(productCategory))
                    .ToListAsync();
        }
    }
}