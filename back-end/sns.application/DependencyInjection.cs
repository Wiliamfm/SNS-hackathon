using Microsoft.Extensions.DependencyInjection;
using sns.application.Auth;

namespace sns.application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        return services;
    }
}
