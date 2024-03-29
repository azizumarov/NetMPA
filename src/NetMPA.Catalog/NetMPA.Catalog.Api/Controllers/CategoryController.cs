﻿using AutoMapper;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using NetMPA.Catalog.Api.Controllers.Requests;
using NetMPA.Catalog.Api.Models;
using NetMPA.Catalog.Bll.Interfaces.Services;
using NetMPA.Catalog.Bll.Models.RequestParams;
using NetMPA.Messages.Dto;

//using NetMPA.Catalog.Bll.Models;

namespace NetMPA.Catalog.Api.Controllers
{
    /// <summary>
    /// Catalog API
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/category")]
 
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<ProductController> logger;
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;
        private readonly IBus bus;

        public CategoryController(ICategoryService categoryService, IMapper mapper, ILogger<ProductController> logger, IBus bus)
        {
            this.logger = logger;
            this.categoryService = categoryService;            
            this.mapper = mapper;
            this.bus = bus;
        }

        /// <summary>
        /// List of Categories
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories([FromQuery] PagedRequest pagedRequest)
        {
            if (pagedRequest.IsValid())
            {
                pagedRequest.PageIndex = pagedRequest.PageIndex ?? 0;
                pagedRequest.PageSize = pagedRequest.PageSize ?? 25;
            }

            var result = await this.categoryService.List(mapper.Map<PagingParameters>(pagedRequest));            

            return Ok(result.Select(this.mapper.Map<Category>));
        }

        /// <summary>
        /// Category by Id
        /// </summary>
        [HttpGet("{id}")]
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddCategory([FromBody] CategoryAdd category)
        {
            if (category == null) return BadRequest();

            await this.categoryService.Add(mapper.Map<Bll.Models.Category>(category));
            
            await this.bus.Publish<CategoryAdd>(category);

            return StatusCode(201);
        }

        /// <summary>
        /// Update Category
        /// </summary>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateCategory([FromBody] Category category)
        {
            if (category == null) return BadRequest();

            await this.categoryService.Update(mapper.Map<Bll.Models.Category>(category));

            await this.bus.Publish<Category>(category);

            return Ok();
        }

        /// <summary>
        /// Delete Category
        /// </summary>        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteCategory([FromRoute] int categoryId)
        {
            if (categoryId <= 0) return BadRequest();

            await this.categoryService.Delete(categoryId);

            await this.bus.Publish(new DeleteCategoryMessage(){ Id = categoryId});

            return Ok();
        }

    }
}
