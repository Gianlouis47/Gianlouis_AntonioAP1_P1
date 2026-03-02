using Microsoft.EntityFrameworkCore;
using Parcial1.Models;

namespace Parcial1.DAL;

public class Contexto(DbContextOptions<Contexto> options) : DbContext(options)
{
    public DbSet<EntradasHuacales> EntradasHuacales => Set<EntradasHuacales>();

    public DbSet<TiposHuacales> TiposHuacales => Set<TiposHuacales>();

    public DbSet<DetalleHuacales> DetalleHuacales => Set<DetalleHuacales>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Relación: Entrada -> Detalles (1 a muchos)
        modelBuilder.Entity<DetalleHuacales>()
            .HasOne(d => d.Entrada)
            .WithMany(e => e.Detalles)
            .HasForeignKey(d => d.IdEntrada)
            .OnDelete(DeleteBehavior.Cascade);

        // Relación: Tipo -> Detalles (1 a muchos)
        modelBuilder.Entity<DetalleHuacales>()
            .HasOne(d => d.Tipo)
            .WithMany(t => t.Detalles)
            .HasForeignKey(d => d.TipoId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}