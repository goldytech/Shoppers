namespace Shoppers.Core.DataAccess
{
    using Shoppers.Core.DataAccess.Contracts;
    using Shoppers.Core.DataAccess.Repositories;

    public class ServiceUnitOfWork : IServiceUnitOfWork
    {
        public ServiceUnitOfWork()
        {
            this.ProductRepository = new ProductRepository(new ProductDataContext());
        }

        public IProductRepository ProductRepository { get; }
    }
}