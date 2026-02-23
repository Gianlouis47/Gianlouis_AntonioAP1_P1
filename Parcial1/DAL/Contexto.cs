using Microsoft.EntityFrameworkCore;
using Parcial1.Models;

namespace Parcial1.DAL;

public class Contexto : DbContext
{
    public Contexto(DbContextOptions<Contexto> options)
        : base(options)
    {
    }

    public DbSet<EntradasHuacales> EntradasHuacales { get; set; }
}