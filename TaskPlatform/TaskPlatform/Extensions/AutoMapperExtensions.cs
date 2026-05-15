using TaskPlatform.Mappings;

namespace TaskPlatform.Extensions
{
    public static class AutoMapperExtensions
    {
        public static IServiceCollection AddAutoMapperConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UserProfile));

            return services;
        }
    }
}
