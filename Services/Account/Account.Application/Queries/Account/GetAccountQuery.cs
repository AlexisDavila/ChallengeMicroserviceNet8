using System;
using Account.Application.Responses;
using MediatR;

namespace Account.Application.Queries.Account;

public class GetAccountQuery : IRequest<AccountResponse>
{
   public int CustomerId { get; set; }
   public GetAccountQuery(int customerId)
   {
      CustomerId = customerId;
   }
}
