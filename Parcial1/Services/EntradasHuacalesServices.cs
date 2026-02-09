using Parcial1.DAL;
using Parcial1.Models;
using Microsoft.EntityFrameworkCore;

namespace Parcial1.Services;

public class EntradasHuacalesServices
{
    private readonly AppDbContext _context;

    public EntradasHuacalesServices(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(EntradasHuacales entidad)
    {
        _context.EntradasHuacales.Add(entidad);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(EntradasHuacales entidad)
    {
        _context.EntradasHuacales.Update(entidad);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.EntradasHuacales.FindAsync(id);
        if (entity is null) return;

        _context.EntradasHuacales.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<EntradasHuacales>> GetAsync()
    {
        return await _context.EntradasHuacales.AsNoTracking().ToListAsync();
    }

    public async Task<EntradasHuacales?> GetByIdAsync(int id)
    {
        return await _context.EntradasHuacales.FindAsync(id);
    }
}

