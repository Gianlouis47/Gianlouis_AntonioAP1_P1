using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Parcial1.DAL;

public class ContextoFactory : IDesignTimeDbContextFactory<Contexto>
{
    public Contexto CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false)
        .Build();

        var connectionString = configuration.GetConnectionString("SqlServer");

        var optionsBuilder = new DbContextOptionsBuilder<Contexto>();

        optionsBuilder.UseSqlServer(connectionString);

        return new Contexto(optionsBuilder.Options);
    }
}