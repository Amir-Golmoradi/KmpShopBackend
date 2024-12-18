using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KmpShopBackend.Customer.Infrastructure.persistance;
using KmpShopBackend.Src.Customer.Domain.Repository;
using KmpShopBackend.Src.User.Infrastructure.Adapter.Persistance;
using Microsoft.EntityFrameworkCore;

namespace KmpShopBackend.Customer.Core.Extenstions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddKmpShopApiServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddScoped<ICustomerRepository, CustomerRepositoryImpl>();
        services.AddDbContext<CustomerDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        return services;
    }
}