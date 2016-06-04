namespace SharedServices.DataAccess.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel.ProductCatalog;

    /// <summary>
    /// The ProductRepository interface.
    /// </summary>
    public interface IProductRepository : IDataRepository<Product, Guid>
    {
        /// <summary>
        /// The find products by category async.
        /// </summary>
        /// <param name="productCategory">
        ///     The product category.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<List<Product>> FindProductsByCategoryAsync(ProductCategory productCategory);

       
    }
}