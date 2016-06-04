namespace DomainModel.ProductCatalog
{
    using System.Collections.Generic;

    using DomainModel.ProductPrice;

    public class Product : DomainBase
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the product category.
        /// </summary>
        public ProductCategory ProductCategory { get; set; }

        /// <summary>
        /// Gets or sets the product prices.
        /// </summary>
        public List<Price> ProductPrices { get; set; }
    }

    public enum ProductCategory
    {
        /// <summary>
        /// For fashion.
        /// </summary>
        Fashion = 1,

        Electronics = 2,

        DailyNeeds =3
    }
}
