using Blazor.Madiator.Mediator.PipelineBehaviours.Casche;
using Blazor.Madiator.PipelineBehaviours.Mapper;
using System.Reflection;

namespace Blazor.Madiator
{
    public static class MediatorExtensions
    {
        public static IServiceCollection AddCachesFromAssembly(this IServiceCollection services, Assembly assembly)
        {
            var assemblyTypes = assembly.GetTypes();
            var cacheTypes = assemblyTypes.Where(x => x.IsAssignableTo(typeof(ICache)) && !x.IsAbstract && !x.IsInterface);
            var genericInterfaceCacheType = assemblyTypes.First(x => x.IsAssignableTo(typeof(ICache)) && x.IsAbstract && x.IsInterface && x.IsGenericType);
            foreach (var cacheType in cacheTypes)
            {
                var baseCacheType = cacheType.BaseType;
                var genericInterfaceCacheTypeWithParam = genericInterfaceCacheType.MakeGenericType(baseCacheType.GenericTypeArguments);
                if (baseCacheType == null)
                    continue;
                services.AddScoped(genericInterfaceCacheTypeWithParam, cacheType);
            }

            return services;
        }

        public static IServiceCollection AddMappersFromAssembly(this IServiceCollection services, Assembly assembly)
        {
            var assemblyTypes = assembly.GetTypes();
            var mapperTypes = assemblyTypes.Where(x => x.IsAssignableTo(typeof(IMapper)) && !x.IsAbstract && !x.IsInterface).ToList();
            var genericInterfaceMapperType = assemblyTypes.First(x => x.IsAssignableTo(typeof(IMapper)) && x.IsAbstract && x.IsInterface && x.IsGenericType);
            foreach (var mapperType in mapperTypes)
            {
                var baseMapperType = mapperType.BaseType;
                var genericInterfaceMapperTypeWithParam = genericInterfaceMapperType.MakeGenericType(baseMapperType.GenericTypeArguments);
                if (baseMapperType == null)
                    continue;
                services.AddScoped(genericInterfaceMapperTypeWithParam, mapperType);
            }

            return services;
        }
    }
}
