using Zorgi.Business.Notifications;
using Zorgi.Business.Repositories;
using Zorgi.Business.Services;
using Zorgi.Data.Context;
using Zorgi.Data.Repositories;

namespace Zorgi.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            // Contexts
            services.AddScoped<AppDbContext>();

            // Repositories
            services.AddScoped<ICuidadorRepository, CuidadorRepository>();
            services.AddScoped<IAssistidoRepository, AssistidoRepository>();

            // Services
            services.AddScoped<INotifier, Notifier>();
            services.AddScoped<ICuidadorService, CuidadorService>();
            services.AddScoped<IAssistidoService, AssistidoService>();

            return services;
        }
    }
}
