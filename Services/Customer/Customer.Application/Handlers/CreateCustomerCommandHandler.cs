using AutoMapper;
using Customer.Application.Commands;
using Customer.Application.Responses;
using Customer.Domain.Entities;
using Customer.Domain.Repository;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Customer.Application.Handlers;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerResponse>
{
   private readonly ICustomerRepository _customerRepository;
   private readonly IMapper _mapper;
   private readonly ILogger<CreateCustomerCommand> _logger;
   public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, ILogger<CreateCustomerCommand> logger)
   {
      _customerRepository = customerRepository;
      _mapper = mapper;
      _logger = logger;
   }
   
   public async Task<CustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
   {
      _logger.LogInformation($"Start Customer registration.");
      var customerEntity = _mapper.Map<CustomerEntity>(request);
      //var customerEntity = new CustomerEntity();
      _logger.LogInformation($"Creating customerRequest: {request}");
      _mapper.Map(request, customerEntity, typeof(CreateCustomerCommand), typeof(CustomerEntity));
      _logger.LogInformation($"Creating customer with Name: {customerEntity.Name}, Address: {customerEntity.Address}, Phone: {customerEntity.Phone}");
      var createdCustomer = await _customerRepository.AddAsync(customerEntity);
      _logger.LogInformation($"Customer with Id {createdCustomer.Id} created successfully.");
      var result = _mapper.Map<CustomerResponse>(createdCustomer);
      return result;
   }
}
