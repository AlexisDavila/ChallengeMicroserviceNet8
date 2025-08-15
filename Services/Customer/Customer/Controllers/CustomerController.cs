using System;
using System.Net;
using Customer.Application.Commands;
using Customer.Application.Queries;
using Customer.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Api.Controllers;

public class CustomerController : ApiController
{
   private readonly IMediator _mediator;
   private readonly ILogger<CustomerController> _logger;

   public CustomerController(IMediator mediator, ILogger<CustomerController> logger)
   {
      _mediator = mediator;
      _logger = logger;
   }

   [HttpGet]
   [ProducesResponseType(typeof(IEnumerable<CustomerResponse>), (int)HttpStatusCode.OK)]
   public async Task<ActionResult<IEnumerable<CustomerResponse>>> GetCustomers()
   {
      var query = new GetAllCustomersQuery();
      var customers = await _mediator.Send(query);
      return Ok(customers);
   }

   [HttpPost(Name = "CreateCustomer")]
   [ProducesResponseType((int)HttpStatusCode.OK)]
   public async Task<ActionResult<int>> CreateCustomer([FromBody] CreateCustomerCommand command)
   {
      var result = await _mediator.Send(command);
      return Ok(result);
   }

   [HttpPut(Name = "UpdateCustomer")]
   [ProducesResponseType(StatusCodes.Status204NoContent)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]
   public async Task<ActionResult<int>> UpdateCustomer([FromBody] UpdateCustomerCommand command)
   {
      var result = await _mediator.Send(command);
      return NoContent();
   }
   
   [HttpDelete("{id}",Name = "DeleteCustomer")]
   [ProducesResponseType(StatusCodes.Status204NoContent)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]
   public async Task<ActionResult<int>> DeleteCustomer(int id)
   {
      var command = new DeleteCustomerCommand() { Id = id };
      await _mediator.Send(command);
      return NoContent();
   }
}
