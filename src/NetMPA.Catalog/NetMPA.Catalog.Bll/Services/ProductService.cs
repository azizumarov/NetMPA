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
            if (product == null) throw new ArgumentNullException();
            if (string.IsNullOrEmpty(product.Name)) throw new ArgumentException("Name is required");
            if (product.Name.Length > 50) throw new ArgumentException("The Name value cannot exceed 50 characters.");

            return this.productRepository.Add(product);
        }

        public Task Delete(int productId)
        {
            if (productId <= 0) throw new ArgumentException("Id is required");

            return this.productRepository.Delete(productId);
        }

        public Task<Product> Get(int productId)
        {
            if (productId <= 0) throw new ArgumentException("Id is required");

            return this.productRepository.Get(productId);
        }

        public Task<IEnumerable<Product>> List()
        {
            return this.productRepository.GetAll();
        }

        public Task Update(Product product)
        {
            if (product == null) throw new ArgumentNullException();
            if (product.Id <= 0) throw new ArgumentException("Id is required");
            if (string.IsNullOrEmpty(product.Name)) throw new ArgumentException("Name is required");
            if (product.Name.Length > 50) throw new ArgumentException("The Name value cannot exceed 50 characters.");

            return this.productRepository.Update(product);
        }
    }
}
