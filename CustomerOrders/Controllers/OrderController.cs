using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using Azure.Core;
using CustomerOrders.API.DTOs;
using CustomerOrders.Application.Commands.CommandHandlers;
using CustomerOrders.Application.Queries.QueryHandlers;
using CustomerOrders.Application.Commands.Orders.CreateOrders;
using CustomerOrders.Application.Queries.Orders;
using CustomerOrders.Application.Commands.Orders.DeleteOrders;
using CustomerOrders.API.Abstractions;

namespace CustomerOrders.Controllers
{
    /// <summary>
    /// Handles HTTP requests related to Orders.
    /// </summary>
    [Route("api/[controller]")]
    public class OrderController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<OrderController> _logger;
        private readonly IMapper _mapper;

        public OrderController(ILogger<OrderController> logger, IMediator mediator, IMapper mapper, ISender sender) : base(sender)
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
            var command = _mapper.Map<CreateOrderCommand>(request);
            var result = await _mediator.Send(command);
            return result.IsSuccess ? CreatedAtAction(nameof(GetOrder), new { id = result.Value }, result.Value) : HandleFailure(result);
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
            var query = new GetOrderQuery { Id = id };
            var result = await _mediator.Send(query);
            var order = _mapper.Map<OrderDTO>(result);
            return Ok(order);
        }
        /// <summary>
        /// Gets all orders.
        /// </summary>
        /// <returns>A list of orders.</returns>
        /// <response code="200">Returns the list of orders.</response>
        [HttpGet("bydate")]
        public async Task<IActionResult> GetOrdersByDate([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var query = new GetOrdersByDateQuery { StartDate = startDate, EndDateDate = endDate };
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
            var command = new DeleteOrderCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
