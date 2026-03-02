using Parcial1.DAL;
using Parcial1.Models;
using Microsoft.EntityFrameworkCore;

namespace Parcial1.Services;

public class TiposHuacalesServices
{
    private readonly Contexto _context;

    public TiposHuacalesServices(Contexto context)
    {
        _context = context;
    }

    public async Task<List<TiposHuacales>> GetAsync()
    {
        return await _context.TiposHuacales
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<TiposHuacales?> GetByIdAsync(int id)
    {
        return await _context.TiposHuacales
            .FindAsync(id);
    }

    public async Task CreateAsync(TiposHuacales tipo)
    {
        _context.TiposHuacales.Add(tipo);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TiposHuacales tipo)
    {
        _context.TiposHuacales.Update(tipo);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var tipo = await _context.TiposHuacales.FindAsync(id);

        if (tipo is null)
            return;

        _context.TiposHuacales.Remove(tipo);

        await _context.SaveChangesAsync();
    }
}