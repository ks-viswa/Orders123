using Microsoft.EntityFrameworkCore;
using OrderManagement.Models;

namespace OrderManagement.DataAccess
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        private readonly IConfiguration _configuration;
        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DataContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            //options.UseSqlite(_configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}

