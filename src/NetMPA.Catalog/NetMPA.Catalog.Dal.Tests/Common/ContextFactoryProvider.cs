using Microsoft.EntityFrameworkCore;
using Moq;
using NetMPA.Catalog.Dal.SqlContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMPA.Catalog.Dal.Tests.Common
{
    internal class ContextFactoryProvider
    {
        internal static ICatalogContextFactory GetFactory()
        {
            var catalogContext = InMemoryDbContext.GetPostgresDbContext();
            catalogContext.Database.EnsureDeleted();
            catalogContext.Database.EnsureCreated();

            var moqFactory = new Mock<ICatalogContextFactory>();
            moqFactory.Setup(f => f.CreateContext()).Returns(catalogContext);
            return moqFactory.Object;
        }
    }
}
