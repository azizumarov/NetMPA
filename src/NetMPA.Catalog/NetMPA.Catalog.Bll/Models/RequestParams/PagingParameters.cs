using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMPA.Catalog.Bll.Models.RequestParams
{
    public struct PagingParameters
    {
        public static PagingParameters Empty => new PagingParameters(0, 0);

        public int PageIndex { get; }
        public int PageSize { get; }

        public PagingParameters(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
        
    }
}
