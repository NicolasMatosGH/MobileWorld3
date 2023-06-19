using Microsoft.OpenApi.Models;

namespace MobileWorld.API.Configuration
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Mobile World API",
                    Description = "Esta API é feita como parte do curso Programador de Sistemas SENAC",
                    Contact = new OpenApiContact()
                    {
                        Name = "Nicolas",
                        Email = "nbnicolas.matos@gmail.com"
                    }
                });
            });
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("swagger/v1/swagger.json", "v1");
            });
        }
    }
}
