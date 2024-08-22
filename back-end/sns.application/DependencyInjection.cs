using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using sns.application.Auth;
using sns.domain.Entities;

namespace sns.application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();
        return services;
    }
}
