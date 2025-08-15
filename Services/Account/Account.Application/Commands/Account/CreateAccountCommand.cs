using System;
using Account.Application.Responses;
using MediatR;

namespace Account.Application.Commands.Account;

public class CreateAccountCommand:IRequest<bool>
{
   public string? Number { get; set; }
   public Type? Type { get; set; }
   public decimal? InitialBalance { get; set; }
   public bool? Status { get; set; }
   public int? CustomerId { get; set; }
}
