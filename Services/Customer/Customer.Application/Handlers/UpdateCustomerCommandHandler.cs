using System;
using AutoMapper;
using Customer.Application.Commands;
using Customer.Application.Exceptions;
using Customer.Domain.Entities;
using Customer.Domain.Repository;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Customer.Application.Handlers;

public class UpdateCustomerCommandHandler:IRequestHandler<UpdateCustomerCommand, Unit>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
   private readonly ILogger<UpdateCustomerCommand> _logger;

   public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, ILogger<UpdateCustomerCommand> logger)
   {
      _customerRepository = customerRepository;
      _mapper = mapper;
      _logger = logger;
   }

    public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customerToUpdate = await _customerRepository.GetByIdAsync(request.Id);
        if (customerToUpdate == null)
        {
            throw new CustomerNotFoundException(nameof(customerToUpdate), request.Id);
        }
        _mapper.Map(request, customerToUpdate, typeof(UpdateCustomerCommand), typeof(CustomerEntity));
        await _customerRepository.UpdateAsync(customerToUpdate);
         _logger.LogInformation($"Customer with Id {customerToUpdate.Id} is successfully updated.");
        return Unit.Value;
    }
}
