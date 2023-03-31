using NetMPA.Catalog.Bll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMPA.Catalog.Bll.Interfaces.Services
{
    public interface IProductService
    {
        Task<Product> Get(int productId);
        Task<IEnumerable<Product>> List();

        Task Add(Product product);

        Task Update(Product product);

        Task Delete(int productId);
    }
}
