
using Account.Application.Commands.Account;
using Account.Application.Responses;
using Account.Domain.Entities;
using Account.Domain.Repository;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Account.Application.Handlers.Account;

public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, bool>
{
   private readonly IAccountRepository _accountRepository;
   private readonly IMapper _mapper;
   private readonly ILogger<CreateAccountCommandHandler> _logger;

   public CreateAccountCommandHandler(IAccountRepository accountRepossitory, IMapper mapper, ILogger<CreateAccountCommandHandler> logger)
   {
      _accountRepository = accountRepossitory;
      _mapper = mapper;
      _logger = logger;
   }
   public async Task<bool> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
   {
      var account = _mapper.Map<AccountEntity>(request);
      var result = await _accountRepository.CreateAccountAsync(account);
      _logger.LogInformation($"Account with Number {account.Number} successfully created.");
      return result;
   }
}
