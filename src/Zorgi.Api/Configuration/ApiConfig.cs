using Microsoft.AspNetCore.Mvc;

namespace Zorgi.Api.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection WebApiConfig(this IServiceCollection services)
        {
            services.AddOpenApi();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            services.AddControllers();

            return services;
        }

        public static IApplicationBuilder UseMvcConfig(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();

            return app;
        }
    }
}
