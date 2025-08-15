using System;
using Customer.Application.Responses;
using MediatR;

namespace Customer.Application.Commands;

public class UpdateCustomerCommand : IRequest<Unit>
{
   public int Id { get; set; }
   public string? Name { get; set; }
   public string? Address { get; set; }
   public string? Phone { get; set; }
   public string? Password { get; set; }
   public bool? Status { get; set; }
}
