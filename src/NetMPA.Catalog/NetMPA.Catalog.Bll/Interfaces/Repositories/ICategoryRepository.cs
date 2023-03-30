using NetMPA.Catalog.Bll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMPA.Catalog.Bll.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> Get(int id);
        Task<IEnumerable<Category>> GetAll();
        Task Add(Category category);
        Task Update(Category category);
        Task Delete(int id);
    }
}
