using Microsoft.EntityFrameworkCore;
using NetMPA.Catalog.Bll.Interfaces.Repositories;
using NetMPA.Catalog.Bll.Models;
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

        public Task AddAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await dbFactory.CreateContext().Categories.ToListAsync();
        }

        public Task<Category> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Category category)
        {
            throw new NotImplementedException();
        }
    }
}