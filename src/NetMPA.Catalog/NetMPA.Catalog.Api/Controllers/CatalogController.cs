using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetMPA.Catalog.Api.Models;

namespace NetMPA.Catalog.Api.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
 
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(ILogger<CatalogController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// List of categories
        /// </summary>
        [MapToApiVersion("1.0")]
        [HttpGet()]
        [Route("category")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<Category> GetAllCategories()
        {
            return new List<Category>() { new Category()};
        }

        /// <summary>
        /// List of products
        /// </summary>
        [MapToApiVersion("1.0")]
        [HttpGet()]
        [Route("product")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<Product> GetAllProducts()
        {
            return new List<Product>() { new Product() };
        }

        /// <summary>
        /// Add Category
        /// </summary>
        [MapToApiVersion("1.0")]
        [HttpPost]
        [Route("category")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Category AddCategory([FromBody] CategoryAdd category)
        {
            return new Category();
        }

        /// <summary>
        /// Category by Id
        /// </summary>
        [MapToApiVersion("1.0")]
        [HttpGet()]
        [Route("category/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<string> GetCategoryById(int id)
        {
            return new List<string>() { "asdasd", "123123" };
        }

        [MapToApiVersion("2.0")]
        [HttpGet()]
        [Route("category/list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<string> GetAllCategoriesV2()
        {
            return new List<string>() { "asdasd", "123123" };
        }



    }
}
