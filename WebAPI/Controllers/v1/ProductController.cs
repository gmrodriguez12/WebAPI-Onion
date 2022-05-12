using Application.Features.Products.Commands.CreateProductCommand;
using Application.Features.Products.Commands.DeleteProductCommand;
using Application.Features.Products.Commands.UpdateProductCommand;
using Application.Features.Products.Queries.GetAllProductsQuery;
using Application.Features.Products.Queries.GetProductByIdQuery;
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteProductCommand { ProductId = id }));
        }

        //GET api/<controller>/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetProductByIdQuery { ProductId = id }));
        }

        //GET api/<controller>/1
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductParameters filter)
        {
            return Ok(await Mediator.Send(new GetAllProductsQuery { PageNumber = filter.PageNumber, PageSize = filter.PageSize, SubCategoryId = filter.SubCategoryId }));
        }
    }
}
