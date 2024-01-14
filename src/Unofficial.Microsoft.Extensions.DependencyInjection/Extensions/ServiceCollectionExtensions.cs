using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Unofficial.Microsoft.Extensions.DependencyInjection.Extensions
{
    /// <summary>
    /// The service collection extensions class.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// AddAllTypes.
        /// </summary>
        /// <typeparam name="T">First generic Type.</typeparam>
        /// <param name="services">The service collection.</param>
        /// <param name="serviceKey">The service key.</param>
        /// <param name="lifetime">The lifetime.</param>
        /// <param name="assemblies">The assembly owners.</param>
        /// <returns>The modified service collection.</returns>
        public static IServiceCollection AddAllTypes<T>(this IServiceCollection services, object? serviceKey = null, ServiceLifetime lifetime = ServiceLifetime.Transient, params Assembly[] assemblies)
        {
            var typesFromAssemblies = assemblies.SelectMany(a => a.DefinedTypes.Where(t => !t.IsAbstract && t.IsClass && t.GetInterfaces().Contains(typeof(T))));
            foreach (var type in typesFromAssemblies)
                services.Add(new ServiceDescriptor(typeof(T), serviceKey, type, lifetime));

            return services;
        }

        /// <summary>
        /// AddAllTypesTransient.
        /// </summary>
        /// <typeparam name="T">First generic Type.</typeparam>
        /// <param name="services">The service collection.</param>
        /// <param name="serviceKey">The service key.</param>
        /// <param name="assemblies">The assembly owners.</param>
        /// <returns>The modified service collection.</returns>
        public static IServiceCollection AddAllTypesTransient<T>(this IServiceCollection services, object? serviceKey = null, params Assembly[] assemblies)
        {
            return services.AddAllTypes<T>(serviceKey, ServiceLifetime.Transient, assemblies);
        }

        /// <summary>
        /// AddAllTypesScoped.
        /// </summary>
        /// <typeparam name="T">First generic Type.</typeparam>
        /// <param name="services">The service collection.</param>
        /// <param name="serviceKey">The service key.</param>
        /// <param name="assemblies">The assembly owners.</param>
        /// <returns>The modified service collection.</returns>
        public static IServiceCollection AddAllTypesScoped<T>(this IServiceCollection services, object? serviceKey = null, params Assembly[] assemblies)
        {
            return services.AddAllTypes<T>(serviceKey, ServiceLifetime.Scoped, assemblies);
        }

        /// <summary>
        /// AddAllTypesSingleton.
        /// </summary>
        /// <typeparam name="T">First generic Type.</typeparam>
        /// <param name="services">The service collection.</param>
        /// <param name="serviceKey">The service key.</param>
        /// <param name="assemblies">The assembly owners.</param>
        /// <returns>The modified service collection.</returns>
        public static IServiceCollection AddAllTypesSingleton<T>(this IServiceCollection services, object? serviceKey = null, params Assembly[] assemblies)
        {
            return services.AddAllTypes<T>(serviceKey, ServiceLifetime.Singleton, assemblies);
        }
    }
}
