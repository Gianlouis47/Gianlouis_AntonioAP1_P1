using Microsoft.EntityFrameworkCore;
using Parcial1.Components;
using Parcial1.DAL;

var builder = WebApplication.CreateBuilder(args);

// Razor / Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// EF Core (ÚNICA forma correcta para parciales)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

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
