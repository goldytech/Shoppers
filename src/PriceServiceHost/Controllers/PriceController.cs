using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PriceService;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PriceServiceHost.Controllers
{
    [Route("api/[controller]")]
    public class PriceController : Controller
    {
        private readonly IPriceService priceService;

        public PriceController(IPriceService priceService)
        {
            this.priceService = priceService;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<double> Get(Guid id)
        {
            var price = await this.priceService.GetDiscountedPriceAsync(id);
            return price;
        }
 
    }
}
