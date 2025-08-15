using AutoMapper;
using Customer.Application.Queries;
using Customer.Application.Responses;
using Customer.Domain.Repository;
using MediatR;

namespace Customer.Application.Handlers;

public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, List<CustomerResponse>>
{
   private readonly ICustomerRepository _customerRepository;
   private readonly IMapper _mapper;
   public GetAllCustomersQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
   {
      _customerRepository = customerRepository;
      _mapper = mapper;
   }
   public async Task<List<CustomerResponse>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
   {
      var customersList = await _customerRepository.GetAllAsync();

      return _mapper.Map<List<CustomerResponse>>(customersList);
   }
}
