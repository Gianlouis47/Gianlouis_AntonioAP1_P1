namespace Parcial1.Services.Toast;
using Microsoft.Extensions.DependencyInjection;
public static class ToastServiceExtensions
{
    public static IServiceCollection AddToastServices(this IServiceCollection services)
    {
        services.AddScoped<IToastService, ToastService>();
        return services;
    }
}
