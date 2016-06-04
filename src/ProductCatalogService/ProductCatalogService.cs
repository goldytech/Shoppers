namespace ProductCatalogService
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using DomainModel.ProductCatalog;

    using SharedServices.DataAccess.Contracts;
    using SharedServices.Model;

    public class ProductCatalogService : IProductCatalogService
    {
        private readonly IServiceUnitOfWork serviceUnitOfWork;

      

        public ProductCatalogService(IServiceUnitOfWork serviceUnitOfWork)
        {
            this.serviceUnitOfWork = serviceUnitOfWork;
        }

        /// <summary>
        /// The add product.
        /// </summary>
        /// <param name="product">
        ///     The product.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<Promise<bool>> AddProductAsync(Product product)
        {
            var promise = new Promise<bool>();
            try
            {
              await  this.serviceUnitOfWork.ProductRepository.Insert(product).ConfigureAwait(false);
                promise.Result = true;
            }
            catch (Exception exception)
            {

                promise.Exception = exception;
                promise.Result = false;
            }

            return promise;
        }

        public async Task<Promise<List<Product>>> FindProductsByCategoryAsync(ProductCategory productCategory)
        {

            var promise = new Promise<List<Product>>();
            try
            {
                var products = await this.serviceUnitOfWork.ProductRepository.FindProductsByCategoryAsync(productCategory).ConfigureAwait(false);
                promise.Result = products;
            }
            catch (Exception exception)
            {
               promise.Exception = exception;
            }

            return promise;
        }

        public async Task<Promise<Product>> GetProductById(Guid productId)
        {
            var promise = new Promise<Product>();
            var product = await this.serviceUnitOfWork.ProductRepository.GetByIdAsync(productId);
            try
            {
                promise.Result = product;
            }
            catch (Exception exception)
            {

                promise.Exception = exception;
            }
            return promise;
        }

        /// <summary>
        /// The remove product async.
        /// </summary>
        /// <param name="productId">
        /// The product id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<Promise<bool>> RemoveProductAsync(Guid productId)
        {
            var promise = new Promise<bool>();
            try
            {
               await this.serviceUnitOfWork.ProductRepository.Delete(productId).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                promise.Exception = exception;
            }

            return promise;
        }
    }
}