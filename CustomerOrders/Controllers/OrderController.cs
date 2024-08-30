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
    /// Handles HTTP requests related to Orders.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<OrderController> _logger;
        private readonly IMapper _mapper;

        public OrderController(ILogger<OrderController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }
        /// <summary>
        /// Creates a new Order.
        /// </summary>
        /// <param name="Order">The Order to create.</param>
        /// <returns>The created Order.</returns>
        /// <response code="201">Returns the created Order.</response>
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDTO request)
        {
            var command = _mapper.Map<CreateOrderCommandHandlers.Command>(request);
            await _mediator.Send(command);
            return Created();
        }
        /// <summary>
        /// Gets a Order by its ID.
        /// </summary>
        /// <param name="id">The ID of the Order to retrieve.</param>
        /// <returns>The Order with the specified ID.</returns>
        /// <response code="200">Returns the requested Order.</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(Guid id)
        {
            var query = new GetOrderQueryHandler.Query { Id = id };
            var result = await _mediator.Send(query);
            var order = _mapper.Map<OrderDTO>(result);
            return Ok(order);
        }
        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns>A list of products.</returns>
        /// <response code="200">Returns the list of products.</response>
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var query = new GetAllOrdersQueryHandler.Query();
            var result = await _mediator.Send(query);
            var orders = _mapper.Map<List<OrderDTO>>(result);
            return Ok(orders);
        }
        /// <summary>
        /// Deletes a Order by its ID.
        /// </summary>
        /// <param name="id">The ID of the Order to delete.</param>
        /// <returns>No content if the deletion is successful.</returns>
        /// <response code="204">If the deletion is successful.</response>

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var command = new DeleteOrderCommandHandler.Command { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
