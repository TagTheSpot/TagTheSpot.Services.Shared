using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TagTheSpot.Services.Shared.Abstractions.Mappers;

namespace TagTheSpot.Services.Shared.Application.Extensions
{
    public static class MapperExtensions
    {
        public static IServiceCollection AddMappersFromAssemblies(
            this IServiceCollection services,
            Assembly[] assemblies)
        {
            services.Scan(scan =>
                scan.FromAssemblies(assemblies)
                    .AddClasses(classes => classes.AssignableTo(typeof(Mapper<,>)), publicOnly: false)
                    .As(type =>
                    {
                        var baseMapperType = type.BaseType;

                        return baseMapperType != null && baseMapperType.IsGenericType &&
                               baseMapperType.GetGenericTypeDefinition() == typeof(Mapper<,>)
                            ? [baseMapperType]
                            : [];
                    })
                    .WithScopedLifetime());

            return services;
        }

        public static IServiceCollection AddAllMappers(
            this IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            services.Scan(scan =>
                scan.FromAssemblies(assemblies)
                    .AddClasses(classes => classes.AssignableTo(typeof(Mapper<,>)), publicOnly: false)
                    .As(type =>
                    {
                        var baseMapperType = type.BaseType;

                        return baseMapperType != null && baseMapperType.IsGenericType &&
                               baseMapperType.GetGenericTypeDefinition() == typeof(Mapper<,>)
                            ? [baseMapperType]
                            : [];
                    })
                    .WithScopedLifetime());

            return services;
        }
    }
}
