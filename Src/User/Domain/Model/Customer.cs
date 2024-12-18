using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace KmpShopBackend.Customer.Domain
{
    [Table("customers")]
    [Index(nameof(Email), IsUnique = true)]
    public class Customer
    {
        public Customer(long id, string name, string email, string password, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(70)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public override bool Equals(object? obj)
        {
            return obj is Customer customer &&
                   Id == customer.Id &&
                   Name == customer.Name &&
                   Email == customer.Email &&
                   Password == customer.Password &&
                   CreatedAt == customer.CreatedAt &&
                   UpdatedAt == customer.UpdatedAt;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Email, Password, CreatedAt, UpdatedAt);
        }
    }
}
