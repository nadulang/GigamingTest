using Microsoft.EntityFrameworkCore;
using nadya_asp_rest_test1.Models;

namespace nadya_asp_rest_test1
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options): base(options){ }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Driver> Drivers {get; set; }
        public DbSet<Product> Products { get; set; }
   }
}