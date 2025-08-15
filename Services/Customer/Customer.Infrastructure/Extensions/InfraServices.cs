using System;
using Customer.Domain.Repository;
using Customer.Infrastructure.Data;
using Customer.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Customer.Infrastructure.Extensions;

public static class InfraServices
{
   public static IServiceCollection AddInfraServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<CustomerContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("CustomerConnectionString"),
                sqlServerOptions => sqlServerOptions.EnableRetryOnFailure()));
            serviceCollection.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            serviceCollection.AddScoped<ICustomerRepository, CustomerRepository>();
            return serviceCollection;
        }
}
