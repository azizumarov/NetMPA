using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine.Adapter;
using Moq;
using NetMPA.Catalog.Bll.Interfaces.Repositories;
using NetMPA.Catalog.Bll.Interfaces.Services;
using NetMPA.Catalog.Bll.Models;
using NetMPA.Catalog.Bll.Models.RequestParams;
using NetMPA.Catalog.Bll.Services;
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
    public class CategoryRepositoryTests
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
        public async Task CategoryRepository_GetAllCategories()
        {
            //Arrange
            var categoryRepository = new CategoryRepository(contextFactory);
            var category = new Category() { Name = "Category 1", Image = new Uri("c:/testUri") };
            await categoryRepository.Add(category);
            await this.catalogContext.SaveChangesAsync();

            //Act
            var result = await categoryRepository.GetAll(new PagingParameters(0, 10));

            //Assert
            Assert.IsNotNull(result);
        }

    }
}
