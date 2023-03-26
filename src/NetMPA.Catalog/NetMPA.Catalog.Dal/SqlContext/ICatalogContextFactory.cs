using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMPA.Catalog.Dal.SqlContext
{
    public interface ICatalogContextFactory
    {
        CatalogContext CreateContext();
    }
}
