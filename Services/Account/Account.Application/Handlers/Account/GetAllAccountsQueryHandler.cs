using System;
using Account.Application.Queries.Account;
using Account.Application.Responses;
using Account.Domain.Repository;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Account.Application.Handlers.Account;

public class GetAllAccountsQueryHandler : IRequestHandler<GetAllAccountsQuery, List<AccountResponse>>
{
   private readonly IAccountRepository _accountRepository;
   private readonly IMapper _mapper;
   public GetAllAccountsQueryHandler(IAccountRepository accountRepository, IMapper mapper)
   {
      _accountRepository = accountRepository;
      _mapper = mapper;
   }
   public async Task<List<AccountResponse>> Handle(GetAllAccountsQuery request, CancellationToken cancellationToken)
   {
      var account = await _accountRepository.GetAllAccountsAsync();
      var result = _mapper.Map<List<AccountResponse>>(account);
      return result;
   }
}
