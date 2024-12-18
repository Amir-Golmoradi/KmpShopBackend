using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace KmpShopBackend.Customer.Domain
{
    public class CustomerBuilder
    {
        private long _id;
        private string _name;
        private string _email;
        private string _password;
        private DateTime _createdAt;
        private DateTime _updatedAt;

        // Default constructor
        public CustomerBuilder()
        {
            _createdAt = DateTime.Now;  // Default value
            _updatedAt = DateTime.Now;  // Default value
        }

        // Method to set Id
        public CustomerBuilder WithId(long id)
        {
            _id = id;
            return this;
        }

        // Method to set Name
        public CustomerBuilder WithName(string name)
        {
            _name = name ?? throw new ArgumentNullException(nameof(name), "Name cannot be null.");
            return this;
        }

        // Method to set Email
        public CustomerBuilder WithEmail(string email)
        {
            _email = email ?? throw new ArgumentNullException(nameof(email), "Email cannot be null.");
            return this;
        }

        // Method to set Password
        public CustomerBuilder WithPassword(string password)
        {
            _password = password ?? throw new ArgumentNullException(nameof(password), "Password cannot be null.");
            return this;
        }

        // Method to set CreatedAt (Optional, default is DateTime.Now)
        public CustomerBuilder WithCreatedAt(DateTime createdAt)
        {
            _createdAt = createdAt;
            return this;
        }

        // Method to set UpdatedAt (Optional, default is DateTime.Now)
        public CustomerBuilder WithUpdatedAt(DateTime updatedAt)
        {
            _updatedAt = updatedAt;
            return this;
        }

        // Build method to create the Customer object
        public Customer Build()
        {
            return new Customer(_id, _name, _email, _password, _createdAt, _updatedAt);
        }
    }
}
