using System;
using Account.Application.Commands.Account;
using Account.Application.Responses;
using Account.Domain.Entities;
using Account.Domain.Repository;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Account.Application.Handlers.Movement;

public class CreateMovementCommandHandler : IRequestHandler<CreateAccountCommand, bool>
{
   private readonly IMovementRepository _movementRepository;
   private readonly IMapper _mapper;
   private readonly ILogger<CreateAccountCommand> _logger;
   public CreateMovementCommandHandler(IMovementRepository movementRepository, IMapper mapper, ILogger<CreateAccountCommand> logger)
   {
      _movementRepository = movementRepository;
      _mapper = mapper;
      _logger = logger;
   }
   public async Task<bool> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
   {
      _logger.LogInformation($"Start of movement transaction.");
      var movementEntity = _mapper.Map<MovementEntity>(request);
      var createdMovement = await _movementRepository.CreateMovementAsync(movementEntity);

      var result = _mapper.Map<MovementResponse>(createdMovement);
      //modificar el tipo de retorno
      return true;
   }
}
