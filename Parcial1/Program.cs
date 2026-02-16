using Microsoft.EntityFrameworkCore;
using Parcial1.Components;
using Parcial1.DAL;
using Parcial1.Services;

var builder = WebApplication.CreateBuilder(args);

// Razor / Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// EF Core 
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<EntradasHuacalesServices>();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();


try
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        context.Database.Migrate();
        Console.WriteLine(" Migraciones aplicadas exitosamente");
    }
}
catch (Exception ex)
{
    Console.WriteLine($" Error al aplicar migraciones: {ex.Message}");
    Console.WriteLine($"Stack: {ex.StackTrace}");
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
