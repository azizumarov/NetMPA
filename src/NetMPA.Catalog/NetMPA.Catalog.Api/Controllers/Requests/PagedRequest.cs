using Microsoft.AspNetCore.Mvc;

namespace NetMPA.Catalog.Api.Controllers.Requests
{
    public class PagedRequest
    {
        [FromQuery]
        public int Skip { get; set; }

        [FromQuery]
        public int Take { get; set; }
        
    }
}
