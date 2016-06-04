namespace PriceService
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// The PriceService interface.
    /// </summary>
    public interface IPriceService
    {
        /// <summary>
        /// The get discounted price async.
        /// </summary>
        /// <param name="productId">
        /// The product id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<double> GetDiscountedPriceAsync(Guid productId);
    }
}
