using Microsoft.EntityFrameworkCore;
using NetMPA.Catalog.Bll.Interfaces.Repositories;
using NetMPA.Catalog.Bll.Models;
using NetMPA.Catalog.Bll.Models.RequestParams;
using NetMPA.Catalog.Dal.SqlContext;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace NetMPA.Catalog.Dal.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ICatalogContextFactory dbFactory;

        public CategoryRepository(ICatalogContextFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public async Task Add(Category category)
        {
            await dbFactory.CreateContext().Categories.AddAsync(category);
            
        }

        public async Task Delete(int id)
        {
            await dbFactory.CreateContext().Categories.Where(category => category.Id == id).ExecuteDeleteAsync();
        }

        public async Task<IEnumerable<Category>> GetAll(PagingParameters pagingParameters)
        {
            return await dbFactory.CreateContext().Categories.Skip(pagingParameters.PageIndex* pagingParameters.PageSize).Take(pagingParameters.PageSize).ToListAsync();
        }

        public async Task<Category> Get(int id)
        {
            return await dbFactory.CreateContext().Categories.Where(category => category.Id == id).FirstAsync();
        }

        public async Task Update(Category category)
        {
            var old = await dbFactory.CreateContext().Categories.Where(cat => cat.Id == category.Id).SingleAsync();
            if (old == null) throw new ApplicationException("Category not found");

            old.Name = category.Name;
            old.Parent = category.Parent;
            old.Image = category.Image;

            await dbFactory.CreateContext().SaveChangesAsync();
        }
    }
}