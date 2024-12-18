using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KmpShopBackend.Src.User.Application.Request
{
    public record CreatedCustomerRequest(
        long Id,
        string Name,
        string Email,
        string Password
    );
}