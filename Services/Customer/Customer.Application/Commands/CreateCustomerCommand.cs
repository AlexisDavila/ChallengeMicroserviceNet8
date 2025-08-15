using Customer.Application.Responses;
using MediatR;

namespace Customer.Application.Commands;

public class CreateCustomerCommand : IRequest<CustomerResponse>
{
   public string? Name { get; set; }
   public string? Address { get; set; }
   public string? Phone { get; set; }
   public string? Password { get; set; }
   public bool? Status { get; set; }
   
}
