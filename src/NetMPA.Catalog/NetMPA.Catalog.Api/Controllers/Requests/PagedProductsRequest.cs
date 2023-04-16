using Microsoft.AspNetCore.Mvc;

namespace NetMPA.Catalog.Api.Controllers.Requests
{
    public class PagedProducsRequest:PagedRequest
    {
        [FromQuery]
        public int? CategoryID { get; set; }

        public bool IsValid() 
        {
            if (CategoryID.HasValue && CategoryID < 0) throw new Exception("Category ID cannot be less than 0");            

            return base.IsValid(); 
        }
        
    }
}
