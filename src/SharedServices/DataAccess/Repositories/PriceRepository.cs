namespace SharedServices.DataAccess.Repositories
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using DomainModel.ProductPrice;

    using Microsoft.EntityFrameworkCore;

    using SharedServices.DataAccess.Contracts;

    public class PriceRepository : IPriceRepository
    {
        private readonly PriceDataContext priceDataContext;

        public PriceRepository(PriceDataContext priceDataContext)
        {
            this.priceDataContext = priceDataContext;
        }

        public Task<Price> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Price>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task Insert(Price entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(Price entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<double> GetDiscountedPrice(Guid productId)
        {
            var discountedPriceProduct =
                await
                this.priceDataContext.Prices.FirstOrDefaultAsync(
                    p => p.ProductId.Equals(productId) && p.PriceType == PriceType.Sale).ConfigureAwait(false);
            return discountedPriceProduct.Cost;
        }
    }
}