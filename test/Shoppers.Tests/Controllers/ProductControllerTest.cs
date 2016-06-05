using Moq;
using ProductCatalogService;
using ProductCatalogServiceHost.Controllers;
using Xunit;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Http;
using SharedServices.Model;
using DomainModel.ProductCatalog;

namespace Shoppers.Tests.Controllers
{
    public class ProductControllerTest
    {
        private  ProductController subjectunderTest;
        private readonly Mock<IProductCatalogService> mockProductCatalogService;
        public ProductControllerTest()
        {
            mockProductCatalogService = new Mock<IProductCatalogService>();
            subjectunderTest = new ProductController(mockProductCatalogService.Object);
           
        }
        [Fact]
        public void Api_Should_Return_Bad_Request_When_Parameter_Is_Empty()
        {
            var result = Assert.IsType<BadRequestObjectResult>(subjectunderTest.Get(Guid.Empty).Result);
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public void Api_Should_Return_Internal_Server_Error_When_Promise_Has_Exception()
        {
            var mockPromise = new Promise<Product> { Exception = new Exception("Some Fake Error"), Result = null };
            mockProductCatalogService.Setup(s => s.GetProductById(It.IsAny<Guid>()).Result).Returns(mockPromise);
            subjectunderTest = new ProductController(mockProductCatalogService.Object);
            var result = Assert.IsType<StatusCodeResult>(subjectunderTest.Get(Guid.NewGuid()).Result);
            Assert.Equal(500, result.StatusCode);
        } 
    }
}
