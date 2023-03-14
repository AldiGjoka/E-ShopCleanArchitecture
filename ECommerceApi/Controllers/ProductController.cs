using Application.Features.Products.ProductItems.Command.CreateProductItem;
using Application.Features.Products.ProductItems.Command.DeleteProductItem;
using Application.Features.Products.ProductItems.Command.UpdateProductItem;
using Application.Features.Products.ProductItems.Query.GetProductItemById;
using Application.Features.Products.ProductItems.Query.GetProductItemWithBrandAndType;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductItem>>> GetAllProducts()
        {
            var result = await _mediator.Send(new GetProductItemWithBrandAndTypeQuery());

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductItem>> GetProductById(int id)
        {
            var product = new GetProductItemByIdQuery() { Id = id };
            var result = await _mediator.Send(product);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ProductItem>> CreateProduct([FromBody] CreateProductItemCommand product)
        {
            var result = await _mediator.Send(product);

            return CreatedAtAction(nameof(GetProductById), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProduct(int id, [FromBody] UpdateProductItemCommand product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(product);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var productToDelete = new DeleteProductItemCommand() { Id = id };
            await _mediator.Send(productToDelete);

            return NoContent();
        }
    }
}
