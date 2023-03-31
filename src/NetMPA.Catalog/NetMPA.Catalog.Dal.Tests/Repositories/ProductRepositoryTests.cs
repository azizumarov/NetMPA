using NetMPA.Catalog.Bll.Models;
using NetMPA.Catalog.Dal.Repositories;
using NetMPA.Catalog.Dal.SqlContext;
using NetMPA.Catalog.Dal.Tests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMPA.Catalog.Dal.Tests.Repositories
{
    public class ProductRepositoryTests
    {
        private ICatalogContextFactory contextFactory;
        private CatalogContext catalogContext;

        [SetUp]
        public void Setup()
        {
            this.contextFactory = ContextFactoryProvider.GetFactory();
            this.catalogContext = contextFactory.CreateContext();
        }

        [Test]
        public async Task ProductRepository_GetAllProducts()
        {
            //Arrange
            var productRepository = new ProductRepository(contextFactory);
            var product = new Product() { Name = "Product 1", Description = "Test Product 1", Amount = 1, Price=0.0m , Image = new Uri("c:/testUri") };
            await productRepository.Add(product);
            await this.catalogContext.SaveChangesAsync();

            //Act
            var result = await productRepository.GetAll();

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
