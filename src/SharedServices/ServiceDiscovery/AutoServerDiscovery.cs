using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedServices.ServiceDiscovery
{
    public class AutoServerDiscovery
    {
        public Uri GetServiceUriFromRegistry(Services service )
        {
            // In real implementation it will query the consul.io cluster return the appropriate instance

            switch (service)
            {
                case Services.ProductCatalogService:
                    return new Uri("http://localhost:10862/");
                   
                case Services.PriceService:
                    break;
                default:
                    break;
            }
            return null;

        }
    }

    public enum Services
    {
        ProductCatalogService,
        PriceService
    }
}
