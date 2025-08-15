using System;
using Customer.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Customer.Infrastructure.Data;

public class CustomerContextSeed
{
   public static async Task SeedAsync(CustomerContext customerContext, ILogger<CustomerContextSeed> logger)
   {
      if (!customerContext.Customers.Any())
      {
         customerContext.Customers.AddRange(GetCustomers());
         await customerContext.SaveChangesAsync();
         logger.LogInformation($"Customers Database: {typeof(CustomerContext).Name} seeded!.");
      }
   }

   private static IEnumerable<CustomerEntity> GetCustomers()
   {
      return new List<CustomerEntity>
      {
         new()
         {
            Name = "Alexis Davila",
            Gender = Domain.Enum.Gender.Male,
            Identification = "123456789",
            Address = "Lima #123",
            Phone = "123-456-789",
            Password = "admin",
            Status = true
         },
      }; 
   }  
}