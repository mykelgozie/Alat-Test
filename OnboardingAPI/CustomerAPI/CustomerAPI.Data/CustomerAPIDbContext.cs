using CustomerAPI.CustomerAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.CustomerAPI.Data
{
    public class CustomerAPIDbContext : IdentityDbContext<Customer>
    {
        public CustomerAPIDbContext(DbContextOptions<CustomerAPIDbContext> options)
            : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
