using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TagTheSpot.Services.Shared.Abstractions.Mappers;

namespace TagTheSpot.Services.Shared.Application.Extensions
{
    public static class MapperExtensions
    {
        public static IServiceCollection AddMappersFromAssembly(
            this IServiceCollection services,
            params Assembly[] assemblies)
        {
            services.Scan(scan =>
                scan.FromAssemblies(assemblies)
                    .AddClasses(classes => classes.AssignableTo(typeof(Mapper<,>)), publicOnly: false)
                    .As(type =>
                    {
                        var baseMapperType = type.BaseType;

                        return baseMapperType is not null && baseMapperType.IsGenericType &&
                               baseMapperType.GetGenericTypeDefinition() == typeof(Mapper<,>)
                            ? [baseMapperType]
                            : [];
                    })
                    .WithScopedLifetime());

            return services;
        }

        public static IServiceCollection AddMapper<TSource, TDestination, TMapper>(
            this IServiceCollection services)
            where TSource : class
            where TDestination : class
            where TMapper : Mapper<TSource, TDestination>
        {
            services.AddScoped<Mapper<TSource, TDestination>, TMapper>();

            return services;
        }
    }
}
