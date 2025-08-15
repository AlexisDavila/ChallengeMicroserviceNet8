using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Npgsql;
using System;
using System.Threading;

namespace Account.Infrastructure.Extensions;

public static class DbExtension
{
   public static IHost MigrateDatabase<TContext>(this IHost host)
   {
      using (var scope = host.Services.CreateScope())
      {
            var services = scope.ServiceProvider;
            var config = services.GetRequiredService<IConfiguration>();
            var logger = services.GetRequiredService<ILogger<TContext>>();
            try
            {
               logger.LogInformation("Account DB Migration Started");
               ApplyMigrations(config);
               logger.LogInformation("Account DB Migration Completed");
            }
            catch (Exception ex)
            {
               logger.LogError(ex, "An error occurred while migrating the database.");
               throw;
            }
      }
      return host;
   }

   private static void ApplyMigrations(IConfiguration config)
   {
      var retry = 5;
      while (retry > 0)
      {
         try
         {
            using var connection = new NpgsqlConnection(config.GetValue<string>("DatabaseSettings:ConnectionString"));
            connection.Open();
            using var cmd = new NpgsqlCommand
            {
               Connection = connection
            };
            cmd.CommandText = "DROP TABLE IF EXISTS Account";
            cmd.ExecuteNonQuery();
            cmd.CommandText = @"CREATE TABLE Account(Id SERIAL PRIMARY KEY, 
                                             Number VARCHAR(5) NOT NULL,
                                             Type VARCHAR(15) NOT NULL,
                                             InitialBalance DECIMAL(10,2) NOT NULL,
                                             Status BOOLEAN NOT NULL,
                                             CustomerId INT NOT NULL)";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO Account(Number, Type, InitialBalance,Status,CustomerId) VALUES('478758','Savings','2000',true,1);";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "DROP TABLE IF EXISTS Movement";
            cmd.ExecuteNonQuery();
            cmd.CommandText = @"CREATE TABLE Movement(Id SERIAL PRIMARY KEY, 
                                             Date DEFAULT CURRENT_TIMESTAMP,
                                             Type VARCHAR(15) NOT NULL,
                                             Value DECIMAL(10,2) NOT NULL,
                                             Balance DECIMAL(10,2) NOT NULL,
                                             AccountId INT NOT NULL,
                                             FOREIGN KEY (AccountId) REFERENCES Account(Id))";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO Movement(AccountId,Type, Value, Balance) VALUES (1,'Deposito', 575.00, 3000.00);";
            cmd.ExecuteNonQuery();
            // Exit loop if successful
            break; 
         } catch (Exception ex) {
            retry--;
            if (retry == 0)
            {
               throw;
            }
            //Wait for 2 seconds
            Thread.Sleep(2000); 
         }
      }
   }
}
