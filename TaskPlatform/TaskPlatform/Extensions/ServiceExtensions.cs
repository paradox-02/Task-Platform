using System.Runtime.CompilerServices;
using TaskPlatform.Services;

namespace TaskPlatform.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<UserService>();
        }
    }
}
