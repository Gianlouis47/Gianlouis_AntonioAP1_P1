using Parcial1.DAL;
using Parcial1.Models;
using Microsoft.EntityFrameworkCore;

namespace Parcial1.Services;

public class EntradasHuacalesServices
{
    private readonly Contexto _context;

    public EntradasHuacalesServices(Contexto context)
    {
        _context = context;
    }

    // Insertar
    public async Task CreateAsync(EntradasHuacales entidad)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            foreach (var detalle in entidad.Detalles)
            {
                var tipo = await _context.TiposHuacales
                    .FirstOrDefaultAsync(t => t.TipoId == detalle.TipoId);

                if (tipo is null)
                    throw new Exception($"Tipo {detalle.TipoId} no existe.");

                if (tipo.Existencia < detalle.Cantidad)
                    throw new Exception($"No hay suficiente existencia de {tipo.Descripcion}.");

                tipo.Existencia -= detalle.Cantidad;
            }

            _context.EntradasHuacales.Add(entidad);

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    // Modificar
    public async Task UpdateAsync(EntradasHuacales entidad)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var anterior = await _context.EntradasHuacales
                .Include(e => e.Detalles)
                .FirstOrDefaultAsync(e => e.IdEntrada == entidad.IdEntrada);

            if (anterior is null)
                throw new Exception("Entrada no encontrada.");

            // 1️⃣ devolver existencia anterior
            foreach (var detalle in anterior.Detalles)
            {
                var tipo = await _context.TiposHuacales
                    .FirstAsync(t => t.TipoId == detalle.TipoId);

                tipo.Existencia += detalle.Cantidad;
            }

            // eliminar detalles antiguos
            _context.DetalleHuacales.RemoveRange(anterior.Detalles);

            // aplicar nuevos detalles
            foreach (var detalle in entidad.Detalles)
            {
                var tipo = await _context.TiposHuacales
                    .FirstAsync(t => t.TipoId == detalle.TipoId);

                if (tipo.Existencia < detalle.Cantidad)
                    throw new Exception($"No hay suficiente existencia de {tipo.Descripcion}.");

                tipo.Existencia -= detalle.Cantidad;

                // importante: asegurar FK
                detalle.IdEntrada = entidad.IdEntrada;
            }

            // actualizar datos generales
            _context.Entry(anterior).CurrentValues.SetValues(entidad);

            // agregar nuevos detalles
            await _context.DetalleHuacales.AddRangeAsync(entidad.Detalles);

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    // Eliminar
    public async Task DeleteAsync(int id)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var entidad = await _context.EntradasHuacales
                .Include(e => e.Detalles)
                .FirstOrDefaultAsync(e => e.IdEntrada == id);

            if (entidad is null)
                return;

            // devolver existencia
            foreach (var detalle in entidad.Detalles)
            {
                var tipo = await _context.TiposHuacales
                    .FirstAsync(t => t.TipoId == detalle.TipoId);

                tipo.Existencia += detalle.Cantidad;
            }

            _context.EntradasHuacales.Remove(entidad);

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    // Listar
    public async Task<List<EntradasHuacales>> GetAsync()
    {
        return await _context.EntradasHuacales
            .Include(e => e.Detalles)
            .ThenInclude(d => d.Tipo)
            .AsNoTracking()
            .ToListAsync();
    }

    // BUSCAR
    public async Task<EntradasHuacales?> GetByIdAsync(int id)
    {
        return await _context.EntradasHuacales
            .Include(e => e.Detalles)
            .ThenInclude(d => d.Tipo)
            .FirstOrDefaultAsync(e => e.IdEntrada == id);
    }
}