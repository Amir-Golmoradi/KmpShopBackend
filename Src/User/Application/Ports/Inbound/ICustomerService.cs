using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KmpShopBackend.Src.User.Application.Dto;
using KmpShopBackend.Src.User.Application.Request;

namespace KmpShopBackend.Src.Customer.Application.Ports.Inbound
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAll();
        Task<CustomerDto?> GetById(long id);
        Task<CustomerDto?> GetByEmail(string email);
        Task<CustomerDto> Insert(CreatedCustomerRequest request);
        Task Update(long id, UpdatedCustomerRequest request);
        Task<bool> IsCustomerPresent(long id);
        Task Delete(long id);

    }
}