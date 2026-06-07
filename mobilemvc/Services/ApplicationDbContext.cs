using Microsoft.EntityFrameworkCore;
using mobilemvc.Models;

namespace mobilemvc.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }

}
