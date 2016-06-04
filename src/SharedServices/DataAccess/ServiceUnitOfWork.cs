namespace SharedServices.DataAccess
{
    using Contracts;
    using Repositories;

    public class ServiceUnitOfWork : IServiceUnitOfWork
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceUnitOfWork"/> class.
        /// </summary>
        public ServiceUnitOfWork()
        {
            this.ProductRepository = new ProductRepository(new ProductDataContext());
            this.PriceRepository = new PriceRepository(new PriceDataContext());
        }

        public IProductRepository ProductRepository { get; }

        public IPriceRepository PriceRepository { get; }
    }
}