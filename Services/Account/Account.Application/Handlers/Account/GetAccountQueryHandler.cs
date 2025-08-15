using System;
using Account.Application.Queries.Account;
using Account.Application.Responses;
using Account.Domain.Repository;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Account.Application.Handlers;

public class GetAccountQueryHandler : IRequestHandler<GetAccountQuery, AccountResponse>
{
   private readonly IAccountRepository _accountRepository;
   private readonly ILogger<GetAccountQueryHandler> _logger;
   private readonly IMapper _mapper;
   public GetAccountQueryHandler(IAccountRepository accountRepository, IMapper mapper, ILogger<GetAccountQueryHandler> logger)
   {
      _accountRepository = accountRepository;
      _logger = logger;
      _mapper = mapper;
   }
   public async Task<AccountResponse> Handle(GetAccountQuery request, CancellationToken cancellationToken)
   {
      var account = await _accountRepository.GetAccountAsync(request.CustomerId);
      _logger.LogInformation($"Account: {account.Number} - {account.CustomerId} ");
      var result = _mapper.Map<AccountResponse>(account);
      return result;
   }
}
