using Application.Features.Products.ProductTypes.Command.CreateProductType;
using Application.Features.Products.ProductTypes.Command.DeleteProductType;
using Application.Features.Products.ProductTypes.Command.UpdateProductType;
using Application.Features.Products.ProductTypes.Query.GetProductTypeById;
using Application.Features.Products.ProductTypes.Query.GetProductTypes;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<ActionResult<List<ProductType>>> GetAllProductTypes()
        {
            var result = await _mediator.Send(new GetProductTypesQuery());

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductType>> GetProductTypeById(int id)
        {
            var productType = new GetProductTypeByIdQuery() { Id = id };

            var productFromDb = await _mediator.Send(productType);

            return Ok(productFromDb);
        }

        [HttpPost]
        public async Task<ActionResult<ProductType>> CreateProductType([FromBody] CreateProductTypeCommand productType)
        {
            var result = await _mediator.Send(productType);

            return CreatedAtAction(nameof(GetProductTypeById), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProductType(int id, [FromBody] UpdateProductTypeCommand productType)
        {
            if(id != productType.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(productType);

            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProductType(int id)
        {
            var productToBeDeleted = new DeleteProductTypeCommand() { Id = id };
            await _mediator.Send(productToBeDeleted);

            return NoContent();
        }
    }
}
