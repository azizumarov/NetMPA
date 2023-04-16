using Microsoft.AspNetCore.Mvc;

namespace NetMPA.Catalog.Api.Controllers.Requests
{
    public class PagedRequest
    {
        [FromQuery]
        public int? PageIndex { get; set; }

        [FromQuery]
        public int? PageSize { get; set; }

        public bool IsValid() 
        {
            if (PageIndex.HasValue && PageIndex < 0) throw new Exception("Page index cannot be less than 0");
            if (PageIndex.HasValue && PageIndex < 0) throw new Exception("Page index cannot be less than 0");

            return true; 
        }
        
    }
}
