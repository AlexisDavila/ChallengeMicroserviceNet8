using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Customer.Infrastructure.Data;

public class CustomerContextFactory : IDesignTimeDbContextFactory<CustomerContext>
{
   public CustomerContext CreateDbContext(string[] args)
   {
      var optionsBuilder = new DbContextOptionsBuilder<CustomerContext>();
      optionsBuilder.UseSqlServer("Server=tcp:free-sql-mi-0211048.public.043134450b7b.database.windows.net,3342;Persist Security Info=False;User ID=administrador;Password=Libertad&Americ@2022_1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;");
      //"Server=localhost,1433;Database=CustomerDb;User Id=sa;Password=Your_password123;TrustServerCertificate=True;");

      return new CustomerContext(optionsBuilder.Options);
   }
}
