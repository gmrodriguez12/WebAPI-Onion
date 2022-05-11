using Application.Features.Products.Commands.CreateProductCommand;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.v1
{

    [ApiVersion("1.0")]
    public class ProductController : BaseApiController
    {
        //POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommand product)
        {
            return Ok(await Mediator.Send(product));
        }
    }
}
