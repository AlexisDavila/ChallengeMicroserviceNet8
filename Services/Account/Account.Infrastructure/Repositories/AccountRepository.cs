using Account.Application.Responses;
using Account.Domain.Entities;
using Account.Domain.Repository;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Account.Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
   private readonly IConfiguration _configuration;

   public AccountRepository(IConfiguration configuration)
   {
      _configuration = configuration;
   }
   
   public async Task<List<AccountEntity>> GetAllAccountsAsync()
   {
      await using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
      var accounts = await connection.QueryAsync<AccountEntity>($"SELECT * FROM Account");
      
      return accounts.ToList();
   }

   public async Task<AccountEntity> GetAccountAsync(int customerId)
   {
      await using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
      var account = await connection.QueryFirstOrDefaultAsync<AccountEntity>
               ($"SELECT * FROM Account WHERE CustomerId = {customerId};");
      if (account == null)
      {
         //Implement a way to handle the case when no account is found

         //return new AccountEntity { ProductName = "No Account", Amount = 0, Description = "No Account Availables" };
      }
      return account;
   }
   public async Task<bool> CreateAccountAsync(AccountEntity account)
   {
      await using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
      var affected = await connection.ExecuteAsync
            (@$"INSERT INTO Account(Number,Type,InitialBalance,Status,CustomerId) 
            VALUES ({account.Number}, {account.Type}, {account.InitialBalance}, {account.Status}, {account.CustomerId})"
            );

      if (affected == 0)
      {
            return false;
      }
      return true;
   }

   /*Account(Number,Type,InitialBalance,Status,ustomerId */
   public async Task<bool> UpdateAccountAsync(AccountEntity account)
   {
      await using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
   var affected = await connection.ExecuteAsync
      (@$"UPDATE Account SET 
         Number={account.Number}, 
         Type = {account.Type}, 
         InitialBalance={account.InitialBalance}, 
         Status={account.Status}, 
         CustomerId={account.CustomerId} 
            WHERE Id = {account.Id}"
      );
      if (affected == 0)
      {
         return false;
      }
      return true;
   }

   public async Task<bool> DeleteAccountAsync(string accountNumber)
   {
      await using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
      var affected = await connection.ExecuteAsync($"DELETE FROM Account WHERE Number = {accountNumber}");

      if (affected == 0)
      {
         return false;
      }

      return true;
   }
}
