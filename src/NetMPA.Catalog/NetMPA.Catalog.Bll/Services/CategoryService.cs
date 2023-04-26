using NetMPA.Catalog.Bll.Interfaces.Repositories;
using NetMPA.Catalog.Bll.Interfaces.Services;
using NetMPA.Catalog.Bll.Models;
using NetMPA.Catalog.Bll.Models.RequestParams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMPA.Catalog.Bll.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public Task Add(Category category)
        {
            return this.categoryRepository.Add(category);
        }

        public Task Delete(int categoryId)
        {
            return this.categoryRepository.Delete(categoryId);
        }

        public Task<Category> Get(int categoryId)
        {
            return this.categoryRepository.Get(categoryId);
        }

        public Task<IEnumerable<Category>> List(PagingParameters pagingParameters)
        {
            return this.categoryRepository.GetAll(pagingParameters);
        }

        public Task Update(Category category)
        {
            return this.categoryRepository.Update(category);
        }
    }
}
