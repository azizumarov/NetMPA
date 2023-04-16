using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetMPA.Carting.Api.Models;
using NetMPA.Carting.Bll.Interfaces;
using System.Collections;

namespace NetMPA.Carting.Api.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]

    [ApiController]
    public class CartingController : ControllerBase
    {
        private readonly ILogger<CartingController> logger;
        private readonly ICartingService cartingService;
        private readonly IMapper mapper;

        public CartingController(ICartingService cartingService, ILogger<CartingController> logger, IMapper mapper)
        {
            this.logger = logger;
            this.cartingService = cartingService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Get cart info
        /// </summary>
        [HttpGet("{key}")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Cart>> GetCartInfo([FromRoute] Guid key)
        {
            var result = await this.cartingService.GetCartItems(key);

            if (result == null) return NotFound();
            return Ok(new Cart { Key = key, Items = result.Select(i => mapper.Map<Item>(i)) });
        }


        /// <summary>
        /// Get cart info
        /// </summary>
        [HttpGet("{key}")]
        [MapToApiVersion("2.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Item>>> GetCartInfoV2([FromRoute] Guid key)
        {
            var result = await this.cartingService.GetCartItems(key);

            if (result == null) return NotFound();
            return Ok(result);
        }

    }
}
