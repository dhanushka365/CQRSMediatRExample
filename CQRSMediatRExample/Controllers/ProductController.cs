using CQRSMediatRExample.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSMediatRExample.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ISender sender;

        public ProductController(ISender sender)
        {
            this.sender = sender;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProducts()
        {
            var products = await sender.Send(new GetProductsQuery());
            return Ok(products);
        }


    }
}
