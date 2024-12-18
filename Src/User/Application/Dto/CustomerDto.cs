using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KmpShopBackend.Src.User.Application.Dto
{
    public record CustomerDto
    {
        public long Id { get; init; }
        [Required]
        [MaxLength(70)]
        public string? Name { get; init; }
        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public string? Email { get; init; }
    };
}