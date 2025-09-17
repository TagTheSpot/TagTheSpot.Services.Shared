using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace TagTheSpot.Services.Shared.API.DependencyInjection
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection ConfigureSwaggerGenWithJwt(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                ConfigureSwaggerAuthorization(options);

                var xmlFile = GetSwaggerXmlFile();
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                options.IncludeXmlComments(xmlPath);
            });

            return services;
        }

        private static string GetSwaggerXmlFile()
        {
            return $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
        }

        private static void ConfigureSwaggerAuthorization(SwaggerGenOptions options)
        {
            options.ConfigureAppSecurityDefinitions();
            options.ConfigureAppSecurityRequirements();
        }

        private static SwaggerGenOptions ConfigureAppSecurityDefinitions(this SwaggerGenOptions options)
        {
            options.AddSecurityRequirement(
                new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            }
                        },
                        new string[] { }
                    }
                });

            return options;
        }

        private static SwaggerGenOptions ConfigureAppSecurityRequirements(this SwaggerGenOptions options)
        {
            options.AddSecurityDefinition(
                JwtBearerDefaults.AuthenticationScheme,
                new OpenApiSecurityScheme
                {
                    Name = HeaderNames.Authorization,
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer { token }\""
                });

            return options;
        }
    }
}
