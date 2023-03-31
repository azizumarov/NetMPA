using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using NetMPA.Catalog.Bll.Models;
using NetMPA.Catalog.Dal.SqlContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMPA.Catalog.Dal.Tests.Common
{
    internal static class InMemoryDbContext
    {
        internal class CatalogTestContext : CatalogContext
        {
            public CatalogTestContext()
            {
            }

            public CatalogTestContext(DbContextOptions<CatalogTestContext> options) : base(options)
            {
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<Category>()
                    .Property(mb => mb.Id)
                    .IsRequired();
            }
        }

        public static CatalogContext GetPostgresDbContext()
        {
            var options = new DbContextOptionsBuilder<CatalogTestContext>()
                .UseInMemoryDatabase(TestConfig.NAME_DATA_BASE)
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            return new CatalogTestContext(options);
        }
    }
}
