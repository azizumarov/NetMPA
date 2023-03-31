using NetMPA.Catalog.Bll.Interfaces.Repositories;
using NetMPA.Catalog.Bll.Interfaces.Services;
using NetMPA.Catalog.Bll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace NetMPA.Catalog.Bll.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Task Add(Product product)
        {
            return this.productRepository.Add(product);
        }

        public Task Delete(int productId)
        {
            return this.productRepository.Delete(productId);
        }

        public Task<Product> Get(int productId)
        {
            return this.productRepository.Get(productId);
        }

        public Task<IEnumerable<Product>> List()
        {
            return this.productRepository.GetAll();
        }

        public Task Update(Product product)
        {
            return this.productRepository.Update(product);
        }
    }
}
