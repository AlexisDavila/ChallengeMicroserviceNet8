using System;
using Account.Application.Queries.Movement;
using Account.Application.Responses;
using Account.Domain.Repository;
using AutoMapper;
using MediatR;

namespace Account.Application.Handlers.Movement;

public class GetMovementQueryHandler : IRequestHandler<GetMovementQuery, List<MovementResponse>>
{
   private readonly IMovementRepository _movementRepository;
   private readonly IMapper _mapper;
   public GetMovementQueryHandler(IMovementRepository movementRepository, IMapper mapper)
   {
      _movementRepository = movementRepository;
      _mapper = mapper;
   }
   public async Task<List<MovementResponse>> Handle(GetMovementQuery request, CancellationToken cancellationToken)
   {
      var movements = await _movementRepository.GetMovementsAsync(request.AccountId);
      var listMovements = _mapper.Map<List<MovementResponse>>(movements);
      return listMovements;
   }
}
