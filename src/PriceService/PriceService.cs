namespace PriceService
{
    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    using DomainModel.ProductCatalog;
    using DomainModel.ProductPrice;

    using Newtonsoft.Json;

    using SharedServices.ServiceDiscovery;

    public class PriceService : IPriceService
    {
        public async Task<double> GetDiscountedPriceAsync(Guid productId)
        {
            var productCatalogService = new AutoServerDiscovery();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = productCatalogService.GetServiceUriFromRegistry(Services.ProductCatalogService);
                var response = await client.GetAsync(new Uri($"api/product/{productId}")).ConfigureAwait(false);
                if (!response.IsSuccessStatusCode)
                {
                    return default(double);
                }
                var productJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                var product = JsonConvert.DeserializeObject<Product>(productJson);
                return product?.ProductPrices.FirstOrDefault(p => p.PriceType == PriceType.Sale).Cost ?? default(double);
            }

            
        }
    }
}