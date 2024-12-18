using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KmpShopBackend.Customer.Domain;
using Microsoft.EntityFrameworkCore;

namespace KmpShopBackend.Customer.Infrastructure.persistance;

public class CustomerDbContext : DbContext 
{
    public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
    {
    }

    public DbSet<Domain.Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CustomerDbConfig());
        base.OnModelCreating(modelBuilder);
    }
}
