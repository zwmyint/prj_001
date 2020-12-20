using Microsoft.EntityFrameworkCore;
using API_LoginRegistration.Entities;

namespace API_LoginRegistration.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}