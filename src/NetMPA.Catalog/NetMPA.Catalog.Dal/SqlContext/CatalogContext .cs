using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NetMPA.Catalog.Bll.Models;
using NetMPA.Catalog.Dal.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NetMPA.Catalog.Dal.SqlContext
{
    public class CatalogContext:DbContext
    {
        public CatalogContext()
        {
        }

        public CatalogContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");

            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Product>().ToTable("Product");
        }
    }
}
