using System;
using Account.Domain.Entities;

namespace Account.Domain.Repository;

public interface IMovementRepository
{
   Task<List<Movement>> GetMovementsAsync(string accountId);


   Task<bool> CreateMovementAsync(Movement movement);
   Task<bool> UpdateMovementAsync(Movement movement);
   Task<bool> DeleteMovementAsync(Guid movementId);

}
