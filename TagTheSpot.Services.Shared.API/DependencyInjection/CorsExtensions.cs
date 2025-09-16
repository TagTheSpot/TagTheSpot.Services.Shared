using Microsoft.Extensions.DependencyInjection;

namespace TagTheSpot.Services.Shared.API.DependencyInjection
{
    public static class CorsExtensions
    {
        public const string DevelopmentPolicyName = "Development";

        public static IServiceCollection AddDevelopmentCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(DevelopmentPolicyName, policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            return services;
        }
    }
}
