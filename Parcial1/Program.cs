using Microsoft.EntityFrameworkCore;
using Parcial1.Components;
using Parcial1.DAL;
using Parcial1.Services;
using BlazorBootstrap;

var builder = WebApplication.CreateBuilder(args);

// Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// DbContext
builder.Services.AddDbContext<Contexto>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("SqlContStr"))
);

// Services
builder.Services.AddScoped<EntradasHuacalesServices>();
builder.Services.AddScoped<TiposHuacalesServices>();
builder.Services.AddScoped<DetalleHuacalesServices>();

// BlazorBootstrap
builder.Services.AddBlazorBootstrap();

var app = builder.Build();

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAntiforgery();

//
// Blazor endpoints
//
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();