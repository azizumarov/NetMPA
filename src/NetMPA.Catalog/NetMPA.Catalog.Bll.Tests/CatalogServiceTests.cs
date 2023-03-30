using Moq;
using NetMPA.Catalog.Bll.Interfaces.Repositories;
using NetMPA.Catalog.Bll.Interfaces.Services;
using NetMPA.Catalog.Bll.Models;
using NetMPA.Catalog.Bll.Services;

namespace NetMPA.Catalog.Bll.Tests
{
    public class CatalogServiceTests
    {
        private ICatalogService catalogService;

        [SetUp]
        public void Setup()
        {

            var productRepository = new Mock<IProductRepository>();
            productRepository.Setup(service => service.GetAll()).ReturnsAsync(new List<Product>() { new Product() { Id = 1} } );

            var categoryRepository = new Mock<ICategoryRepository>();
            categoryRepository.Setup(service => service.GetAll()).ReturnsAsync(new List<Category>() { new Category() { Id = 1 } });

            catalogService = new CatalogService(productRepository.Object, categoryRepository.Object);
        }

        [Test]
        public void CatalogService_GetAllCategories()
        {
            var result = catalogService.GetAllCategories();

            Assert.IsNotNull(result);
        }

        [Test]
        public void CatalogService_GetAllProducts()
        {
            var result = catalogService.GetAllProducts();

            Assert.IsNotNull(result);
        }
    }
}