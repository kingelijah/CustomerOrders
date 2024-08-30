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
    /// Handles HTTP requests related to Customers.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CustomerController> _logger;
        private readonly IMapper _mapper;

        public CustomerController(ILogger<CustomerController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }
        /// <summary>
        /// Creates a new Customer.
        /// </summary>
        /// <param name="Order">The Customer to create.</param>
        /// <returns>The created Customer.</returns>
        /// <response code="201">Returns the created Customer.</response>
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerDTO request)
        {
            var command = _mapper.Map<CreateCustomerCommandHandlers.Command>(request);
            await _mediator.Send(command);
            return Created();
        }
        /// <summary>
        /// Gets a Customer by its ID.
        /// </summary>
        /// <param name="id">The ID of the Customer to retrieve.</param>
        /// <returns>The Customer with the specified ID.</returns>
        /// <response code="200">Returns the requested Customer.</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(Guid id)
        {
            var query = new GetCustomerQueryHandler.Query { Id = id };
            var result = await _mediator.Send(query);
            var customer = _mapper.Map<CustomerDTO>(result);
            return Ok(customer);
        }
        /// <summary>
        /// Gets all Customers.
        /// </summary>
        /// <returns>A list of Customers.</returns>
        /// <response code="200">Returns the list of Customers.</response>
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var query = new GetAllCustomersQueryHandler.Query();
            var result = await _mediator.Send(query);
            var customers = _mapper.Map<List<CustomerDTO>>(result);
            return Ok(customers);
        }
        /// <summary>
        /// Updates an existing Customer.
        /// </summary>
        /// <param name="id">The ID of the Customer to update.</param>
        /// <param name="product">The updated Customer information.</param>
        /// <returns>No content if the update is successful.</returns>
        /// <response code="204">If the update is successful.</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(Guid id, [FromBody] UpdateCustomerDTO request)
        {
            var command = _mapper.Map<UpdateCustomerCommandHandler.Command>(request);
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }
        /// <summary>
        /// Deletes a Customers by its ID.
        /// </summary>
        /// <param name="id">The ID of the Customers to delete.</param>
        /// <returns>No content if the deletion is successful.</returns>
        /// <response code="204">If the deletion is successful.</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            var command = new DeleteCustomerCommandHandler.Command { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
