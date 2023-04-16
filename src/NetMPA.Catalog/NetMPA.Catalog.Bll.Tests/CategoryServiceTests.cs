using Moq;
using NetMPA.Catalog.Bll.Interfaces.Repositories;
using NetMPA.Catalog.Bll.Interfaces.Services;
using NetMPA.Catalog.Bll.Models;
using NetMPA.Catalog.Bll.Models.RequestParams;
using NetMPA.Catalog.Bll.Services;

namespace NetMPA.Catalog.Bll.Tests
{
    public class CategoryServiceTests
    {
        private ICategoryService categoryService;

        [SetUp]
        public void Setup()
        {

            var categoryRepository = new Mock<ICategoryRepository>();
            categoryRepository.Setup(service => service.GetAll(new PagingParameters(0,10))).ReturnsAsync(new List<Category>() { new Category() { Id = 1 } });

            categoryService = new CategoryService(categoryRepository.Object);
        }

        [Test]
        public void CategoryService_List()
        {
            var result = categoryService.List(new PagingParameters(0,10));

            Assert.IsNotNull(result);
        }

    }
}