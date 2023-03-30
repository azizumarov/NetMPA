using NetMPA.Catalog.Bll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMPA.Catalog.Bll.Interfaces.Services
{
    public interface ICatalogService
    {
        Task<Product> GetProductById(int productId);
        Task<IEnumerable<Product>> GetAllProducts();
        Task<IEnumerable<Category>> GetAllCategories();

    }
}
