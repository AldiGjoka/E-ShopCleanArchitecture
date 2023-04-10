using Application.Features.Products.ProductBrands.Command.CreateProductBrand;
using Application.Features.Products.ProductBrands.Command.DeleteProductBrand;
using Application.Features.Products.ProductBrands.Command.UpdateProductBrand;
using Application.Features.Products.ProductBrands.Query;
using Application.Features.Products.ProductBrands.Query.GetProductBrandById;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceApi.Controllers
{
    [Authorize]
    public class ProductBrandController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public ProductBrandController(IMediator mediatR)
        {
            _mediator = mediatR;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductBrand>>> GetAllProductBrands()
        {
            var result = await _mediator.Send(new GetProductBrandQuery());

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductBrand>> GetProductBrandById(int id)
        {
            var productBrand = new GetProductBrandByIdQuery() { BrandId = id };
            var productBrandFromDb = await _mediator.Send(productBrand);

            return Ok(productBrandFromDb);
        }

        [HttpPost]
        public async Task<ActionResult<ProductBrand>> CreateProductBrand([FromBody] CreateProductBrandCommand productBrand)
        {
            var result = await _mediator.Send(productBrand);

            return CreatedAtAction(nameof(GetProductBrandById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProductBrand(int id, [FromBody] UpdateProductBrandCommand productBrand)
        {
            if(id != productBrand.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(productBrand);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductBrand(int id)
        {
            var productToDelete = new DeleteProductBrandCommand() { Id = id };

            await _mediator.Send(productToDelete);

            return NoContent();
        }
    }
}
