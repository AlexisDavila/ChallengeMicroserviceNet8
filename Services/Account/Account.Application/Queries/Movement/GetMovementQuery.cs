using System;
using System.ComponentModel.DataAnnotations;
using Account.Application.Responses;
using MediatR;

namespace Account.Application.Queries.Movement;

public class GetMovementQuery : IRequest<List<MovementResponse>>
{
   
   public int AccountId { get; set; }
   public GetMovementQuery(int accountId)
   {
      AccountId = accountId;
   }
}
