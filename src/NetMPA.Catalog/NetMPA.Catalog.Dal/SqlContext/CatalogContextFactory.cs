using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMPA.Catalog.Dal.SqlContext
{
    public class CatalogContextFactory : ICatalogContextFactory
    {
        private readonly string connectionString;

        public CatalogContextFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public CatalogContext CreateContext()
        {
            var opt = new DbContextOptionsBuilder<CatalogContext>().UseNpgsql(connectionString).Options;
            return new CatalogContext(opt);
        }
    }
}
