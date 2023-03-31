using Microsoft.EntityFrameworkCore;
using NetMPA.Catalog.Bll.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

    }
}
