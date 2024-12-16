using To_Do_app_Backend.Repositories;
using To_Do_app_Backend.Services;
using To_Do_app_Backend.Utilities;

namespace To_Do_app_Backend.Extensions;

public static class ServiceExtensions
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        //Services
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IToDoService, ToDoService>();
        
        //Repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IToDoRepository, ToDoRepository>();
        
        //Helpers
        services.AddTransient<TokenHelper>();
    }
}