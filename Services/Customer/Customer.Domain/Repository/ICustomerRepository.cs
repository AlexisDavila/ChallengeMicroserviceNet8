
using Customer.Domain.Entities;

namespace Customer.Domain.Repository;

public interface ICustomerRepository : IAsyncRepository<CustomerEntity>
{
   Task<IEnumerable<CustomerEntity>> GetCustomersByName(string name);
}
