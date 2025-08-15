using Microsoft.EntityFrameworkCore;
using Customer.Domain.Entities;
using Customer.Domain.common;

namespace Customer.Infrastructure.Data;

public class CustomerContext : DbContext
{
   public CustomerContext(DbContextOptions<CustomerContext> options)
       : base(options)
   {
   }
   public DbSet<CustomerEntity> Customers { get; set; }

   public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
   {
      return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
   }
   
    
}
