using System;
using Customer.Application.Commands;
using Customer.Application.Exceptions;
using Customer.Domain.Entities;
using Customer.Domain.Repository;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Customer.Application.Handlers;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Unit>
{
   private readonly ICustomerRepository _customerRepository;
   private readonly ILogger<DeleteCustomerCommand> _logger;

   public DeleteCustomerCommandHandler(ICustomerRepository customerRepository, ILogger<DeleteCustomerCommand> logger)
   {
      _customerRepository = customerRepository;
      _logger = logger;
   }

   public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
   {
      var customerToDelete = await _customerRepository.GetByIdAsync(request.Id);
      if (customerToDelete == null)
      {
         throw new CustomerNotFoundException(nameof(CustomerEntity), request.Id);
      }

      await _customerRepository.DeleteAsync(customerToDelete);
      _logger.LogInformation($"Customer with Id {request.Id} is deleted successfully.");
      return Unit.Value;
   }
}