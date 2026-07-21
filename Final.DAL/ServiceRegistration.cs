using Final.Core.Repositories;
using Final.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
namespace Final.DAL
{
    public static class ServiceRegistration
    {
    
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ISliderRepository, SliderRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IAboutUsRepository, AboutUsRepository>();
            return services;
        }
    }
}
