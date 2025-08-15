using Customer.Domain.Entities;
using Customer.Domain.Repository;
using Customer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Customer.Infrastructure.Repositories;

public class CustomerRepository : RepositoryBase<CustomerEntity>, ICustomerRepository
{
   public CustomerRepository(CustomerContext dbContext)
      : base(dbContext)
   {

   }
   public async Task<IEnumerable<CustomerEntity>> GetCustomersByName(string name)
   {
      var customerList = await _dbContext.Customers
      .Where(c => c.Name != null && c.Name.Contains(name))
      .ToListAsync();
      return customerList;
   }
}
