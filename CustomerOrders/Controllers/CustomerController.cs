using Microsoft.AspNetCore.Mvc;
using MediatR;
using AutoMapper;
using Azure.Core;
using CustomerOrders.API.DTOs;
using CustomerOrders.Application.Commands.CommandHandlers;
using CustomerOrders.Application.Queries.QueryHandlers;
using CustomerOrders.API.Abstractions;
using CustomerOrders.Domain.Shared;
using CustomerOrders.Application.Commands.Customers.CreateCustomers;
using CustomerOrders.Application.Queries.Customers;
using CustomerOrders.Application.Commands.Customers.UpdateCustomers;
using CustomerOrders.Application.Commands.Customers.DeleteCustomers;

namespace CustomerOrders.Controllers
{
    /// <summary>
    /// Handles HTTP requests related to Customers.
    /// </summary>
    [Route("api/[controller]")]
    public class CustomerController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CustomerController> _logger;
        private readonly IMapper _mapper;

        public CustomerController(ILogger<CustomerController> logger, IMediator mediator, IMapper mapper, ISender sender): base (sender)
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
            var command = _mapper.Map<CreateCustomerCommand>(request);
            var result = await _mediator.Send(command);
            return result.IsSuccess ? CreatedAtAction(nameof(GetCustomer), new { id = result.Value }, result.Value) : HandleFailure(result);
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
            var query = new GetCustomerQuery { Id = id };
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
            var query = new GetAllCustomersQuery();
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
            var command = _mapper.Map<UpdateCustomerCommand>(request);
            command.Id = id;
            var result = await _mediator.Send(command);
            return result.IsSuccess ? NoContent() : HandleFailure(result);
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
            var command = new DeleteCustomerCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
