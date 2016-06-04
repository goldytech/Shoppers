namespace DomainModel.ProductPrice
{
    using System;

    using DomainModel.ProductCatalog;

    public class Price  : DomainBase
    {
        public Product Product { get; set; }

        public double Cost { get; set; }

        public PriceType PriceType { get; set; }

        public Guid ProductId { get; set; }
    }

    public enum PriceType
    {
        Daily = 1,

        Sale = 2
    }
}
