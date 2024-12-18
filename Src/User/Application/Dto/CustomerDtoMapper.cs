using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KmpShopBackend.Src.User.Application.Dto;

namespace KmpShopBackend.Customer.Application.Mapper
{
    public static class CustomerMapper
    {

        public static CustomerDto ToDto(Domain.Customer customer)
        {
            if (customer == null) throw new ArgumentNullException(nameof(customer), "Customer not found.");

            return new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email
            };
        }


        public static Domain.Customer ToEntity(CustomerDto dto)
        {
            return dto == null
                ? throw new ArgumentNullException(nameof(dto))
                : new Domain.Customer(
                id: dto.Id,
                name: dto.Name ?? throw new ArgumentNullException(nameof(dto.Name)),
                email: dto.Email ?? throw new ArgumentNullException(nameof(dto.Email)),
                password: string.Empty,
                createdAt: DateTime.Now,
                updatedAt: DateTime.Now
            );
        }

        public static List<CustomerDto> ToDtoList(IEnumerable<Domain.Customer> customers)
        {
            if (customers == null) throw new ArgumentNullException(nameof(customers));

            return customers.Select(ToDto).ToList();
        }


        public static List<Domain.Customer> ToEntityList(IEnumerable<CustomerDto> dtos)
        {
            if (dtos == null) throw new ArgumentNullException(nameof(dtos));

            return dtos.Select(ToEntity).ToList();
        }
    }
}
