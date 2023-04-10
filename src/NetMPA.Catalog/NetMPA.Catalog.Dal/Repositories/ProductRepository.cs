using Microsoft.EntityFrameworkCore;
using NetMPA.Catalog.Bll.Interfaces.Repositories;
using NetMPA.Catalog.Bll.Models;
using NetMPA.Catalog.Dal.SqlContext;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace NetMPA.Catalog.Dal.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContextFactory dbFactory;

        public ProductRepository(ICatalogContextFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public async Task Add(Product product)
        {
            await dbFactory.CreateContext().Products.AddAsync(product);
            await dbFactory.CreateContext().SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            await dbFactory.CreateContext().Products.Where(Product => Product.Id == id).ExecuteDeleteAsync();
            await dbFactory.CreateContext().SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await dbFactory.CreateContext().Products.ToListAsync();
        }

        public async Task<Product> Get(int id)
        {
            return await dbFactory.CreateContext().Products.Where(product => product.Id == id).FirstAsync();
        }

        public async Task Update(Product product)
        {
            var old = await dbFactory.CreateContext().Products.Where(cat => cat.Id == product.Id).SingleAsync();
            if (old == null) throw new ApplicationException("Product not found");

            old.Name = product.Name;
            old.Description = product.Name;
            old.Image = product.Image;
            old.Category = product.Category;
            old.Price = product.Price;
            old.Amount = product.Amount;

        await dbFactory.CreateContext().SaveChangesAsync();
        }
    }
}