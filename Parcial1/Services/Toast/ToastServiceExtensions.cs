using Microsoft.Extensions.DependencyInjection;

namespace Parcial1.Services.Toast;

public static class ToastServiceExtensions
{
    public static IServiceCollection AddToastService(this IServiceCollection services)
        => services.AddScoped<IToastService, ToastService>();
}
