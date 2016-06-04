using Microsoft.AspNetCore.Mvc;
using ProductCatalogService;
using DomainModel.ProductCatalog;
using System.Threading.Tasks;
using System;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductCatalogServiceHost.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductCatalogService productCatalogService;

        public ProductController(IProductCatalogService productCatalogService)
        {
            this.productCatalogService = productCatalogService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            if (id.Equals(Guid.Empty))
            {
                return this.BadRequest();
            }
            var promise = await this.productCatalogService.GetProductById(id);
            if (promise.Exception != null)
            {
                return new OkObjectResult(promise.Result);
            }
            return new StatusCodeResult(500);
        }

       // GET api/product/category/5
        [HttpGet("{id}")]
        [Route("category/{id}", Name = "ProductsListingByCategory")]
        public async Task<IActionResult>Get(int id)
        {
            if (id == 0)
            {
                return this.BadRequest();
            }

            var promise = await this.productCatalogService.FindProductsByCategoryAsync((ProductCategory)id);
            if (promise.Result != null)
            {
                return new OkObjectResult(promise.Result);
            }

            if (promise.Result == null)
            {
                return this.NotFound();
            }

            return promise.Exception != null ? new StatusCodeResult(500) : null;
        }

        // POST api/product
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            var promise = await this.productCatalogService.AddProductAsync(product);
            if (promise.Exception != null)
            {
                return CreatedAtRoute("ProductsListingByCategory", new { controller = "Product", id = product.Id }, product);
            }
            return  new StatusCodeResult(500) ;
        }

       

        // DELETE api/product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id.Equals(Guid.Empty))
            {
                return BadRequest();
            }
            var promise = await this.productCatalogService.RemoveProductAsync(id);
            if (promise.Exception != null)
            {
                return NoContent();
            }
            return new StatusCodeResult(500);
        }
    }
}
