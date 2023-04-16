using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMPA.Catalog.Bll.Models.RequestParams
{
    public struct PagingProductsParameters
    {
        public int? CategoryId { get; }
        public int PageIndex { get; }
        public int PageSize { get; }

        public PagingProductsParameters(int? categoryId, int pageIndex, int pageSize)
        {
            CategoryId = categoryId;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
        
    }
}
