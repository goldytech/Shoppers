namespace ProductCatalogService
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel.ProductCatalog;

    using SharedServices.Model;

    public interface IProductCatalogService
    {
        Task<Promise<bool>>  AddProductAsync(Product product);

        Task<Promise<List<Product>>> FindProductsByCategoryAsync(ProductCategory productCategory);

        Task<Promise<bool>>  RemoveProductAsync(Guid productId);

        Task<Promise<Product>> GetProductById(Guid productId);
    }
}