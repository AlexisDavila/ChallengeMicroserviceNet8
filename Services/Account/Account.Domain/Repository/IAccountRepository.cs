using System;
using Account.Domain.Entities;

namespace Account.Domain.Repository;

public interface IAccountRepository
{
   Task<AccountEntity> GetAccountAsync(int accountId);
   Task<List<AccountEntity>> GetAllAccountsAsync();
   Task<bool> CreateAccountAsync(AccountEntity account);
   Task<bool> UpdateAccountAsync(AccountEntity account);
   Task<bool> DeleteAccountAsync(string accountId);
}
