using System;
using Account.Domain.Entities;

namespace Account.Domain.Repository;

public interface IMovementRepository
{
   Task<List<MovementEntity>> GetMovementsAsync(int accountId);
   Task<bool> CreateMovementAsync(MovementEntity movement);
   Task<bool> UpdateMovementAsync(MovementEntity movement);
   Task<bool> DeleteMovementAsync(int movementId);

}
