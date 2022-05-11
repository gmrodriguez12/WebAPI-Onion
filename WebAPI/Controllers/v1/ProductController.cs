using Application.Features.Products.Commands.CreateProductCommand;
using Application.Features.Products.Commands.DeleteProductCommand;
using Application.Features.Products.Commands.UpdateProductCommand;
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

        //PUT api/<controller>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateProductCommand product)
        {
            if (id != product.ProductId)
                return BadRequest();

            return Ok(await Mediator.Send(product));
        }

        //DELETE api/<controller>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteProductCommand product = new DeleteProductCommand()
            {
                 ProductId = id
            };

            return Ok(await Mediator.Send(product));
        }
    }
}
