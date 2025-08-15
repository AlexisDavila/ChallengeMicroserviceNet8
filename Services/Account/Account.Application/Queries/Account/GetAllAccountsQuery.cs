using System;
using Account.Application.Responses;
using Account.Domain.Entities;
using MediatR;

namespace Account.Application.Queries.Account;

public class GetAllAccountsQuery:IRequest<List<AccountResponse>>
{
   
}
