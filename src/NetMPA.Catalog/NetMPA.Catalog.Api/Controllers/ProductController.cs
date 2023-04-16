using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetMPA.Catalog.Api.Controllers.Requests;
using NetMPA.Catalog.Api.Models;
using NetMPA.Catalog.Bll.Interfaces.Services;
using NetMPA.Catalog.Bll.Models.RequestParams;
//using NetMPA.Catalog.Bll.Models;

namespace NetMPA.Catalog.Api.Controllers
{
    /// <summary>
    /// Product API
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/product")]
 
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> logger;
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public ProductController(ICategoryService categoryService, IProductService productService,IMapper mapper, ILogger<ProductController> logger)
        {
            this.logger = logger;
            this.categoryService = categoryService;
            this.productService = productService;
            this.mapper = mapper;
        }

        /// <summary>
        /// List of Products
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts([FromQuery] PagedRequest pagedRequest)
        {
            if (pagedRequest.IsValid())
            {
                pagedRequest.PageIndex = pagedRequest.PageIndex ?? 0;
                pagedRequest.PageSize = pagedRequest.PageSize ?? 25;
            }

            var result = await this.productService.List(mapper.Map<PagingParameters>(pagedRequest));
            if (result == null) return NotFound();
            return Ok(result.Select(this.mapper.Map<Product>));
        }

        /// <summary>
        /// Product by Id
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Category>> GetProductById(int id)
        {
            var result = await this.categoryService.Get(id);
            if (result == null) return NotFound();
            return Ok(this.mapper.Map<Product>(result));
        }

        /// <summary>
        /// Add Product
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddProduct([FromBody] ProductAdd product)
        {
            if (product == null) return BadRequest();

            await this.productService.Add(mapper.Map<Bll.Models.Product>(product));

            return StatusCode(201);
        }

        /// <summary>
        /// Update Product
        /// </summary>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateProduct([FromRoute] int productId, [FromBody] ProductAdd product)
        {
            if (productId <= 0) return BadRequest();
            if (product == null) return BadRequest();

            await this.productService.Update(mapper.Map<Bll.Models.Product>(product));

            return Ok();
        }

        /// <summary>
        /// Delete Products
        /// </summary>        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteProduct([FromRoute] int productId)
        {
            if (productId <= 0) return BadRequest();

            await this.productService.Delete(productId);

            return Ok();
        }

    }
}
