using Microsoft.EntityFrameworkCore;
using Parcial1.Models; 

namespace Parcial1.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<EntradasHuacales> EntradasHuacales { get; set; }
    }
}
