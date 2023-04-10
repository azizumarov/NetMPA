using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetMPA.Carting.Bll.Interfaces;
using NetMPA.Carting.Bll.Models;
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

        public CartingController(ICartingService cartingService, ILogger<CartingController> logger)
        {
            this.logger = logger;
            this.cartingService = cartingService;
        }

        /// <summary>
        /// Get cart info
        /// </summary>
        [HttpGet("{key}")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetCartInfo([FromRoute] Guid key)
        {
            var result = await this.cartingService.GetCartItems(key);

            if (result == null) return NotFound();
            return Ok(new { cart_key = key, items = result });
        }


        /// <summary>
        /// Get cart info
        /// </summary>
        [HttpGet("{key}")]
        [MapToApiVersion("2.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Item>>> GetCartInfoV2([FromRoute] Guid key)
        {
            var result = await this.cartingService.GetCartItems(key);

            if (result == null) return NotFound();
            return Ok(result);
        }

    }
}
