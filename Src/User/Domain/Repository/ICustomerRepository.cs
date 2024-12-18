using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using KmpShopBackend.Customer.Domain;
using KmpShopBackend.Src.User.Application.Dto;
using KmpShopBackend.Src.User.Application.Request;


namespace KmpShopBackend.Src.Customer.Domain.Repository
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<KmpShopBackend.Customer.Domain.Customer>> GetAllCustomer();
        Task<KmpShopBackend.Customer.Domain.Customer?> GetCustomerById(long customerId);
        Task<KmpShopBackend.Customer.Domain.Customer?> GetCustomerByEmail(string customerEmail);
        Task DeleteCustomer(long id);
        Task<bool> IsCustomerExistsById(long id);
        Task<KmpShopBackend.Customer.Domain.Customer> PersistCustomer(KmpShopBackend.Customer.Domain.Customer customer);
    }
}