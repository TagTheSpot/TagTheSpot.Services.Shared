using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace TagTheSpot.Services.Shared.Application.Extensions
{
    public static class OptionsExtensions
    {
        public static IServiceCollection ConfigureValidatableOnStartOptions<TOptions>(
           this IServiceCollection services,
           string configSectionPath)
           where TOptions : class
        {
            services.AddOptions<TOptions>()
                .BindConfiguration(configSectionPath)
                .ValidateDataAnnotations()
                .ValidateOnStart();

            return services;
        }

        public static TOptions GetOptions<TOptions>(this IServiceProvider serviceProvider)
            where TOptions : class
        {
            return serviceProvider.GetRequiredService<IOptions<TOptions>>().Value;
        }
    }
}
