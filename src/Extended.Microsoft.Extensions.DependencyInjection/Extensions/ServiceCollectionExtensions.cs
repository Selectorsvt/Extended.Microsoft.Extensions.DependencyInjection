using System.Reflection;
using Extended.System.Reflection;
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
        public static IServiceCollection AddAllTypesInheritedOf<T>(this IServiceCollection services, object? serviceKey = null, ServiceLifetime lifetime = ServiceLifetime.Transient, params Assembly[] assemblies)
        {
            if (assemblies == null || assemblies.Length == 0)
                throw new ArgumentNullException(nameof(assemblies));

            var registerType = typeof(T);

            foreach (var type in assemblies.GetInheritedTypes(registerType))
                services.Add(new ServiceDescriptor(type, serviceKey, type, lifetime));

            return services;
        }

        /// <summary>
        /// Adds the all types like using the specified services.
        /// </summary>
        /// <typeparam name="T">The .</typeparam>
        /// <param name="services">The services.</param>
        /// <param name="serviceKey">The service key.</param>
        /// <param name="lifetime">The lifetime.</param>
        /// <param name="assemblies">The assemblies.</param>
        /// <returns>The services collection.</returns>
        public static IServiceCollection AddAllTypesLike<T>(this IServiceCollection services, object? serviceKey = null, ServiceLifetime lifetime = ServiceLifetime.Transient, params Assembly[] assemblies)
        {
            if (assemblies == null || assemblies.Length == 0)
                throw new ArgumentNullException(nameof(assemblies));

            var registerType = typeof(T);
            foreach (var type in assemblies.GetInheritedTypes(registerType))
                services.Add(new ServiceDescriptor(registerType, serviceKey, type, lifetime));

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
            return services.AddAllTypesInheritedOf<T>(serviceKey, ServiceLifetime.Transient, assemblies: assemblies);
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
            return services.AddAllTypesInheritedOf<T>(serviceKey, ServiceLifetime.Scoped, assemblies: assemblies);
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
            return services.AddAllTypesInheritedOf<T>(serviceKey, ServiceLifetime.Singleton, assemblies: assemblies);
        }

        /// <summary>
        /// AddAllTypesTransient.
        /// </summary>
        /// <typeparam name="T">First generic Type.</typeparam>
        /// <param name="services">The service collection.</param>
        /// <param name="serviceKey">The service key.</param>
        /// <param name="assemblies">The assembly owners.</param>
        /// <returns>The modified service collection.</returns>
        public static IServiceCollection AddAllTypesTransientLike<T>(this IServiceCollection services, object? serviceKey = null, params Assembly[] assemblies)
        {
            return services.AddAllTypesLike<T>(serviceKey, ServiceLifetime.Transient, assemblies: assemblies);
        }

        /// <summary>
        /// AddAllTypesScoped.
        /// </summary>
        /// <typeparam name="T">First generic Type.</typeparam>
        /// <param name="services">The service collection.</param>
        /// <param name="serviceKey">The service key.</param>
        /// <param name="assemblies">The assembly owners.</param>
        /// <returns>The modified service collection.</returns>
        public static IServiceCollection AddAllTypesScopedLike<T>(this IServiceCollection services, object? serviceKey = null, params Assembly[] assemblies)
        {
            return services.AddAllTypesLike<T>(serviceKey, ServiceLifetime.Scoped, assemblies: assemblies);
        }

        /// <summary>
        /// AddAllTypesSingleton.
        /// </summary>
        /// <typeparam name="T">First generic Type.</typeparam>
        /// <param name="services">The service collection.</param>
        /// <param name="serviceKey">The service key.</param>
        /// <param name="assemblies">The assembly owners.</param>
        /// <returns>The modified service collection.</returns>
        public static IServiceCollection AddAllTypesSingletonLike<T>(this IServiceCollection services, object? serviceKey = null, params Assembly[] assemblies)
        {
            return services.AddAllTypesLike<T>(serviceKey, ServiceLifetime.Singleton, assemblies: assemblies);
        }
    }
}
