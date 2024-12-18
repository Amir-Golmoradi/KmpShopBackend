using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KmpShopBackend.Customer.Application.Mapper;
using KmpShopBackend.Customer.Domain;
using KmpShopBackend.Src.Customer.Application.Ports.Inbound;
using KmpShopBackend.Src.Customer.Domain.Repository;
using KmpShopBackend.Src.User.Application.Dto;
using KmpShopBackend.Src.User.Application.Request;

namespace KmpShopBackend.Src.User.Application.Ports.Outbound
{
    public class CustomerManagementService : ICustomerService
    {
        private readonly ICustomerRepository repository;

        public CustomerManagementService(ICustomerRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<CustomerDto>> GetAll()
        {
            var customers = await repository.GetAllCustomer();
            return CustomerMapper.ToDtoList(customers);
        }

        public async Task<CustomerDto?> GetByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be null or empty.", nameof(email));
            }
            var customer = await repository.GetCustomerByEmail(email);
            if (customer == null)
            {
                throw new ArgumentException(nameof(customer), "Customer Not Found");
            }
            return CustomerMapper.ToDto(customer);
        }

        public async Task<CustomerDto?> GetById(long id)
        {
            if (!await repository.IsCustomerExistsById(id))
            {
                throw new ArgumentException("ID must be greater than zero.", nameof(id));
            }
            var customer = await repository.GetCustomerById(id);
            if (customer == null)
            {
                throw new ArgumentException(nameof(customer), "Customer Not Found");
            }
            return CustomerMapper.ToDto(customer);

        }


        public async Task<CustomerDto> Insert(CreatedCustomerRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            var customer = new CustomerBuilder()
            .WithId(request.Id)
            .WithName(request.Name)
            .WithEmail(request.Email)
            .WithPassword(request.Password)
            .Build();
            await repository.PersistCustomer(customer);
            return CustomerMapper.ToDto(customer);
        }

        public Task Update(long id, UpdatedCustomerRequest request)
        {
            throw new NotImplementedException();
        }



        public async Task<bool> IsCustomerPresent(long id)
        {
            return await repository.IsCustomerExistsById(id);
        }

        public async Task Delete(long id)
        {
            if (!await repository.IsCustomerExistsById(id))
            {
                throw new ArgumentException($"Customer with ID {id} not found.", nameof(id));
            }
            await repository.DeleteCustomer(id);
        }
    }

}