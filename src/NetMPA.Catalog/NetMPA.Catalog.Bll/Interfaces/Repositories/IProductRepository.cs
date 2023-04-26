using NetMPA.Catalog.Bll.Models;
using NetMPA.Catalog.Bll.Models.RequestParams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMPA.Catalog.Bll.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<Product> Get(int id);
        Task<IEnumerable<Product>> GetAll(PagingProductsParameters pagingParameters);
        Task Add(Product product);
        Task Update(Product product);
        Task Delete(int id);
    }
}
