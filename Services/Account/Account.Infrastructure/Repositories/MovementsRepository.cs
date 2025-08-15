using System;
using Account.Domain.Entities;
using Account.Domain.Repository;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Account.Infrastructure.Repositories;

public class MovementsRepository : IMovementRepository
{
   private readonly IConfiguration _configuration;

   public MovementsRepository(IConfiguration configuration)
   {
      _configuration = configuration;
   }
   public async Task<List<MovementEntity>> GetMovementsAsync(int accountId)
   {
      await using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
      var movements = await connection.QueryFirstOrDefaultAsync<List<MovementEntity>>
               ($"SELECT * FROM Movement WHERE AccountId = {accountId}");
      if (movements == null)
      {
         //Implement a way to handle the case when no account is found

         //return new AccountEntity { ProductName = "No Account", Amount = 0, Description = "No Account Availables" };
      }
      return movements;
   }

   /*Movement(Date,Type,Value,Balance,AccountId) */
   public async Task<bool> CreateMovementAsync(MovementEntity movement)
   {
      await using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
      var affected = await connection.ExecuteAsync
         (@$"INSERT INTO Movement(AccountId,Type,Value,Balance)
            VALUES ({movement.AccountId}, {movement.Type}, {movement.Value}, {movement.Balance})"
         );

      if (affected == 0)
      {
         return false;
      }
      return true;
   }

   public Task<bool> UpdateMovementAsync(MovementEntity movement)
   {
      // Implementation for updating a movement
      throw new NotImplementedException();
   }

   public Task<bool> DeleteMovementAsync(int movementId)
   {
      // Implementation for deleting a movement
      throw new NotImplementedException();
   }
   

}