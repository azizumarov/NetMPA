using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetMPA.Catalog.Api.Models;
using NetMPA.Catalog.Bll.Interfaces.Services;
//using NetMPA.Catalog.Bll.Models;

namespace NetMPA.Catalog.Api.Controllers
{
    /// <summary>
    /// Catalog API
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
 
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ILogger<CatalogController> logger;
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public CatalogController(ICategoryService categoryService, IProductService productService,IMapper mapper, ILogger<CatalogController> logger)
        {
            this.logger = logger;
            this.categoryService = categoryService;
            this.productService = productService;
            this.mapper = mapper;
        }

        /// <summary>
        /// List of Categories
        /// </summary>
        [HttpGet()]
        [Route("category")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {
            var result = await this.categoryService.List();
            if (result == null) return NotFound();
            return Ok(result.Select(this.mapper.Map<Category>));
        }

        /// <summary>
        /// Category by Id
        /// </summary>
        [HttpGet()]
        [Route("category/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            var result = await this.categoryService.Get(id);
            if (result == null) return NotFound();
            return Ok(this.mapper.Map<Category>(result));
        }

        /// <summary>
        /// Add Category
        /// </summary>
        [HttpPost]
        [Route("category")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddCategory([FromBody] CategoryAdd category)
        {
            if (category == null) return BadRequest();

            await this.categoryService.Add(new Bll.Models.Category()
                {
                    Name = category.Name,
                    Image = category.Image,
                    Parent = new Bll.Models.Category() { Id = category.ParentId }
                }
            );

            return StatusCode(201);
        }

        /// <summary>
        /// Update Category
        /// </summary>
        [HttpPut]
        [Route("category/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateCategory([FromRoute] int categoryId, [FromBody] CategoryAdd category)
        {
            if (category == null) return BadRequest();

            await this.categoryService.Add(new Bll.Models.Category()
            {
                Name = category.Name,
                Image = category.Image,
                Parent = new Bll.Models.Category() { Id = category.ParentId }
            }
            );

            return Ok();
        }

        /// <summary>
        /// Delete Category
        /// </summary>        
        [HttpDelete]
        [Route("category/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteCategory([FromRoute] int categoryId)
        {
            if (categoryId <= 0) return BadRequest();

            await this.categoryService.Delete(categoryId);

            return Ok();
        }

        /// <summary>
        /// List of Products
        /// </summary>
        [HttpGet()]
        [Route("product")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var result = await this.productService.List();
            if (result == null) return NotFound();
            return Ok(result.Select(this.mapper.Map<Product>));
        }

        /// <summary>
        /// Product by Id
        /// </summary>
        [HttpGet()]
        [Route("product/{id}")]
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
        [Route("product")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddProduct([FromBody] ProductAdd product)
        {
            if (product == null) return BadRequest();

            await this.productService.Add(new Bll.Models.Product()
                {
                    Name = product.Name,
                    Image = product.Image,
                    Category = product.Category != null ? new Bll.Models.Category { Id = product.Category.Id}: null,
                    Price = product.Price,
                    Amount = product.Amount               
                }
            );

            return StatusCode(201);
        }

        /// <summary>
        /// Update Product
        /// </summary>
        [HttpPut]
        [Route("product/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateProduct([FromRoute] int productId, [FromBody] ProductAdd product)
        {
            if (productId <= 0) return BadRequest();
            if (product == null) return BadRequest();

            await this.productService.Update(new Bll.Models.Product()
                {
                    Id = productId,
                    Name = product.Name,
                    Image = product.Image,
                    Category = product.Category != null ? new Bll.Models.Category { Id = product.Category.Id } : null,
                    Price = product.Price,
                    Amount = product.Amount
                }
            );

            return Ok();
        }

        /// <summary>
        /// Delete Products
        /// </summary>        
        [HttpDelete]
        [Route("product/{id}")]
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
