namespace Shoppers.Core.DataAccess.Contracts
{
    public interface IServiceUnitOfWork
    {
        IProductRepository ProductRepository { get; }
    }
}