using NetMPA.Catalog.Bll.Models;
using NetMPA.Catalog.Bll.Models.RequestParams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMPA.Catalog.Bll.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<Category> Get(int categoryId);
        Task<IEnumerable<Category>> List(PagingParameters pagingParameters);

        Task Add(Category category);

        Task Update(Category category);

        Task Delete(int categoryId);
    }
}
