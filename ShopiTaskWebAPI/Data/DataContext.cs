using Microsoft.EntityFrameworkCore;
using ShopiTaskWebAPI.Models;

namespace ShopiTaskWebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
    }
}
