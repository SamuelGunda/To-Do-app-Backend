using To_Do_app_Backend.Repositories;
using To_Do_app_Backend.Services;

namespace To_Do_app_Backend.Extensions;

public static class ServiceExtensions
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        //Services
        services.AddScoped<IUserService, UserService>();
        
        //Repositories
        services.AddScoped<IUserRepository, UserRepository>();
    }
}