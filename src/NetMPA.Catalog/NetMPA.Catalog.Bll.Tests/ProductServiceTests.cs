using Moq;
using NetMPA.Catalog.Bll.Interfaces.Repositories;
using NetMPA.Catalog.Bll.Interfaces.Services;
using NetMPA.Catalog.Bll.Models;
using NetMPA.Catalog.Bll.Models.RequestParams;
using NetMPA.Catalog.Bll.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMPA.Catalog.Bll.Tests
{
    internal class ProductServiceTests
    {   
        private IProductService productService;

        [SetUp]
        public void Setup()
        {

            var productRepository = new Mock<IProductRepository>();
            productRepository.Setup(service => service.GetAll(new PagingParameters(0, 10))).ReturnsAsync(new List<Product>() { new Product() { Id = 1 } });

            productService = new ProductService(productRepository.Object);
        }

        [Test]
        public void ProductService_List()
        {
            var result = productService.List(new PagingParameters(0, 10));

            Assert.IsNotNull(result);
        }

        
    }
}
