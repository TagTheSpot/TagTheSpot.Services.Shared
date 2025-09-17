using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection;
using TagTheSpot.Services.Shared.Abstractions.Options;

namespace TagTheSpot.Services.Shared.Application.Extensions
{
    public static class OptionsExtensions
    {
        public static IServiceCollection ConfigureValidatableOnStartOptions<TOptions>(
           this IServiceCollection services,
           string? configSectionPath = default)
           where TOptions : class, IAppOptions
        {
            var sectionPath = configSectionPath ?? TOptions.SectionName;

            services.AddOptions<TOptions>()
                .BindConfiguration(sectionPath)
                .ValidateDataAnnotations()
                .ValidateOnStart();

            return services;
        }

        public static IServiceCollection ConfigureValidatableOnStartOptionsFromAssembly(
            this IServiceCollection services,
            Assembly assembly)
        {
            var optionTypes = assembly
                .GetTypes()
                .Where(t => !t.IsAbstract && !t.IsInterface && typeof(IAppOptions).IsAssignableFrom(t));

            foreach (var type in optionTypes)
            {
                var method = typeof(OptionsExtensions)
                    .GetMethod(nameof(ConfigureValidatableOnStartOptions),
                        BindingFlags.Public | BindingFlags.Static)!
                    .MakeGenericMethod(type);

                method.Invoke(null, [ services, null ]);
            }

            return services;
        }

        public static IServiceCollection ConfigureValidatableOnStartOptionsFromAllAssemblies(
            this IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var assembly in assemblies)
            {
                services.ConfigureValidatableOnStartOptionsFromAssembly(assembly);
            }

            return services;
        }

        public static TOptions GetOptions<TOptions>(this IServiceProvider serviceProvider)
            where TOptions : class
        {
            return serviceProvider.GetRequiredService<IOptions<TOptions>>().Value;
        }
    }
}
