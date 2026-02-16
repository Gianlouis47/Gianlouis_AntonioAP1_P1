using Microsoft.EntityFrameworkCore;
using Parcial1.DAL;
using Parcial1.Models;

namespace Parcial1.Services;

public class EntradasHuacalesServices
{
    private readonly AppDbContext _context;

    public EntradasHuacalesServices(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<EntradaHuacales>> GetAllAsync()
    {
        return await _context.EntradasHuacales
            .OrderByDescending(x => x.Fecha)
            .ToListAsync();
    }

    public async Task<EntradaHuacales?> GetByIdAsync(int id)
    {
        return await _context.EntradasHuacales
            .FirstOrDefaultAsync(x => x.IdEntrada == id);
    }

    public async Task CreateAsync(EntradaHuacales entity)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(entity.NombreCliente))
                throw new ArgumentException("El nombre del cliente no puede estar vacío");

            if (entity.Cantidad <= 0)
                throw new ArgumentException("La cantidad debe ser mayor a 0");

            if (entity.Precio <= 0)
                throw new ArgumentException("El precio debe ser mayor a 0");

            Console.WriteLine($"[CreateAsync] INICIANDO GUARDADO");
            Console.WriteLine($"[CreateAsync] Cliente: {entity.NombreCliente}");
            Console.WriteLine($"[CreateAsync] Fecha: {entity.Fecha}");
            Console.WriteLine($"[CreateAsync] Cantidad: {entity.Cantidad}");
            Console.WriteLine($"[CreateAsync] Precio: {entity.Precio}");

            Console.WriteLine($"[CreateAsync] Agregando entidad al contexto...");
            _context.EntradasHuacales.Add(entity);

            Console.WriteLine($"[CreateAsync] Estado del contexto: {_context.ChangeTracker.DebugView.ShortView}");

            Console.WriteLine($"[CreateAsync] Guardando en BD...");
            var result = await _context.SaveChangesAsync();

            Console.WriteLine($"[CreateAsync] ÉXITO: {result} registros guardados");
            Console.WriteLine($"[CreateAsync] ID generado: {entity.IdEntrada}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[CreateAsync] ERROR: {ex.GetType().Name} - {ex.Message}");
            if (ex.InnerException != null)
                Console.WriteLine($"[CreateAsync] Inner Exception: {ex.InnerException.Message}");
            Console.WriteLine($"[CreateAsync] StackTrace: {ex.StackTrace}");
            throw;
        }
    }

    public async Task UpdateAsync(EntradaHuacales entity)
    {
        _context.EntradasHuacales.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.EntradasHuacales
            .FirstOrDefaultAsync(x => x.IdEntrada == id);

        if (entity != null)
        {
            _context.EntradasHuacales.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}

