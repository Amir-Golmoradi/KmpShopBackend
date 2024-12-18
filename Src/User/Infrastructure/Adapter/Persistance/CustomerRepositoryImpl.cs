using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KmpShopBackend.Customer.Infrastructure.persistance;
using KmpShopBackend.Src.Customer.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace KmpShopBackend.Src.User.Infrastructure.Adapter.Persistance
{
    public class CustomerRepositoryImpl : ICustomerRepository
    {
        private readonly CustomerDbContext dbContext;

        public CustomerRepositoryImpl(CustomerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<IEnumerable<KmpShopBackend.Customer.Domain.Customer>> GetAllCustomer()
        {
            return await dbContext.Customers.ToListAsync();
        }

        public async Task<KmpShopBackend.Customer.Domain.Customer?> GetCustomerByEmail(string customerEmail)
        {
            return await dbContext.Customers.FindAsync(customerEmail);
        }

        public async Task<KmpShopBackend.Customer.Domain.Customer?> GetCustomerById(long customerId)
        {
            return await dbContext.Customers.FindAsync(customerId);

        }

        public async Task DeleteCustomer(long id)
        {
            var customer = await dbContext.Customers.FindAsync(id);
            if (customer != null)
            {
                dbContext.Customers.Remove(customer);
                await dbContext.SaveChangesAsync();
            }

        }

        public async Task<bool> IsCustomerExistsById(long id)
        {
            return await dbContext.Customers.AnyAsync(c => c.Id == id);

        }

        public async Task<KmpShopBackend.Customer.Domain.Customer> PersistCustomer(KmpShopBackend.Customer.Domain.Customer customer)
        {
            if (customer.Id == default)
            {
                dbContext.Customers.Add(customer);
            }
            else
            {
                dbContext.Customers.Update(customer);
            }

            await dbContext.SaveChangesAsync();
            return customer;
        }
    }
}