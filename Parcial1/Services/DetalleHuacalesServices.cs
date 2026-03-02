using Parcial1.DAL;
using Parcial1.Models;
using Microsoft.EntityFrameworkCore;

namespace Parcial1.Services;

public class DetalleHuacalesServices
{
    private readonly Contexto _context;

    public DetalleHuacalesServices(Contexto context)
    {
        _context = context;
    }

    public async Task<List<DetalleHuacales>> GetByEntradaAsync(int entradaId)
    {
        return await _context.DetalleHuacales
            .Where(d => d.IdEntrada == entradaId)
            .Include(d => d.Tipo)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task CreateAsync(DetalleHuacales detalle)
    {
        _context.DetalleHuacales.Add(detalle);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int detalleId)
    {
        var detalle = await _context.DetalleHuacales.FindAsync(detalleId);

        if (detalle is null)
            return;

        _context.DetalleHuacales.Remove(detalle);

        await _context.SaveChangesAsync();
    }
}