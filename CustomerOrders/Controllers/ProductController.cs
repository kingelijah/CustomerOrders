using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using Azure.Core;
using CustomerOrders.API.DTOs;
using CustomerOrders.Application.Commands.CommandHandlers;
using CustomerOrders.Application.Queries.QueryHandlers;

namespace CustomerOrders.Controllers
{
    /// <summary>
    /// Handles HTTP requests related to products.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ProductController> _logger;
        private readonly IMapper _mapper;

        public ProductController(ILogger<ProductController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }
        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="product">The product to create.</param>
        /// <returns>The created product.</returns>
        /// <response code="201">Returns the created product.</response>
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDTO request)
        {
            var command = _mapper.Map<CreateProductCommandHandlers.Command>(request);
            await _mediator.Send(command);
            return Created();
        }
        /// <summary>
        /// Gets a product by its ID.
        /// </summary>
        /// <param name="id">The ID of the product to retrieve.</param>
        /// <returns>The product with the specified ID.</returns>
        /// <response code="200">Returns the requested product.</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var query = new GetProductQueryHandler.Query { Id = id };
            var result = await _mediator.Send(query);
            var product = _mapper.Map<ProductDTO>(result);
            return Ok(product);
        }
        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns>A list of products.</returns>
        /// <response code="200">Returns the list of products.</response>
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var query = new GetAllProductsQueryHandler.Query();
            var result = await _mediator.Send(query);
            var products = _mapper.Map<List<ProductDTO>>(result);
            return Ok(products);
        }
        /// <summary>
        /// Updates an existing product.
        /// </summary>
        /// <param name="id">The ID of the product to update.</param>
        /// <param name="product">The updated product information.</param>
        /// <returns>No content if the update is successful.</returns>
        /// <response code="204">If the update is successful.</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductDTO request)
        {
            var command = _mapper.Map<UpdateProductCommandHandler.Command>(request);
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }
        /// <summary>
        /// Deletes a product by its ID.
        /// </summary>
        /// <param name="id">The ID of the product to delete.</param>
        /// <returns>No content if the deletion is successful.</returns>
        /// <response code="204">If the deletion is successful.</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var command = new DeleteProductCommandHandler.Command { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
