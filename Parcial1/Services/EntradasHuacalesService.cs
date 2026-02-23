using Microsoft.EntityFrameworkCore;
using Parcial1.DAL;
using Parcial1.Models;
using Parcial1.Models;
using System.Linq.Expressions;

namespace Parcial1.Services;

public class EntradasHuacalesService
{
    private readonly IDbContextFactory<Contexto> _dbFactory;

    public EntradasHuacalesService(IDbContextFactory<Contexto> dbFactory)
    {
        _dbFactory = dbFactory;
    }

    public async Task<List<EntradasHuacales>> Listar(Expression<Func<EntradasHuacales, bool>> criterio)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();

        return await contexto.EntradasHuacales
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<EntradasHuacales?> Buscar(int entradaId)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();

        return await contexto.EntradasHuacales
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.IdEntrada == entradaId);
    }

    public async Task<bool> Eliminar(int entradaId)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();

        return await contexto.EntradasHuacales
            .Where(e => e.IdEntrada == entradaId)
            .ExecuteDeleteAsync() > 0;
    }

    private async Task<bool> Insertar(EntradasHuacales entrada)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();

        contexto.EntradasHuacales.Add(entrada);

        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(EntradasHuacales entrada)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();

        contexto.EntradasHuacales.Update(entrada);

        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Existe(int entradaId)
    {
        await using var contexto = await _dbFactory.CreateDbContextAsync();

        return await contexto.EntradasHuacales
            .AnyAsync(e => e.IdEntrada == entradaId);
    }

    public async Task<bool> Guardar(EntradasHuacales entrada)
    {
        if (entrada.IdEntrada == 0)
            return await Insertar(entrada);

        if (await Existe(entrada.IdEntrada))
            return await Modificar(entrada);

        return await Insertar(entrada);
    }
}