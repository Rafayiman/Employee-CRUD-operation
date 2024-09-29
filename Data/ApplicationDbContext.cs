using Microsoft.EntityFrameworkCore;
using practice.Models.Entities;

namespace practice.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Employees> Employee { get; set; }
    }
}
