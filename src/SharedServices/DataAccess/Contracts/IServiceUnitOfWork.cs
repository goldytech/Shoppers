namespace SharedServices.DataAccess.Contracts
{
    public interface IServiceUnitOfWork
    {
        /// <summary>
        /// Gets the product repository.
        /// </summary>
        IProductRepository ProductRepository { get; }

        /// <summary>
        /// Gets the price repository.
        /// </summary>
        IPriceRepository PriceRepository { get; }
    }
}