using NetMPA.Catalog.Bll.Interfaces.Repositories;
using NetMPA.Catalog.Bll.Interfaces.Services;
using NetMPA.Catalog.Bll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMPA.Catalog.Bll.Services
{
    public class CatalogService:ICatalogService
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;

        public CatalogService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
        }

        public Task<IEnumerable<Category>> GetAllCategories()
        {
            return this.categoryRepository.GetAll();
        }

        public Task<IEnumerable<Product>> GetAllProducts()
        {
            return this.productRepository.GetAll();
        }

        public Task<Product> GetProductById(int productId)
        {
            return this.productRepository.Get(productId);
        }
    }
}
