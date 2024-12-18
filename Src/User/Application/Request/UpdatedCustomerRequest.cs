using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KmpShopBackend.Src.User.Application.Request
{
    public record UpdatedCustomerRequest(
    [Required]
    [MaxLength(70)]
    string Name,
    [Required]
    [MaxLength(255)]
    [EmailAddress]
    string Email
    );
}