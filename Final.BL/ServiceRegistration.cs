using Final.BL.Services.Abstract;
using Final.BL.Services.Implements;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Final.BL
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ISliderService,SliderService>();
            services.AddScoped<ICategoryService,CategoryService>();
            services.AddScoped<IBlogService, BlogService>();
            services.AddScoped<IAboutUsService, AboutUsService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductParameterService, ProductParameterService>();
            services.AddScoped<IProductImageService, ProductImageService>();
            services.AddScoped<IBasketService, BasketService>();
            return services;
        }
        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(typeof(ServiceRegistration).Assembly);
            return services;
        }
    }
}
