using System;
using DomainModel.ProductPrice;
using System.Threading.Tasks;

namespace SharedServices.DataAccess.Contracts
{
    public interface IPriceRepository : IDataRepository<Price, Guid>
    {
        Task<double> GetDiscountedPrice(Guid productId);
    }
}
