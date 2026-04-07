using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Netlify.HttpClients.Registrars;
using Soenneker.Netlify.OpenApiClientUtil.Abstract;

namespace Soenneker.Netlify.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class NetlifyOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="NetlifyOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddNetlifyOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddNetlifyOpenApiHttpClientAsSingleton()
                .TryAddSingleton<INetlifyOpenApiClientUtil, NetlifyOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="NetlifyOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddNetlifyOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddNetlifyOpenApiHttpClientAsSingleton()
                .TryAddScoped<INetlifyOpenApiClientUtil, NetlifyOpenApiClientUtil>();

        return services;
    }
}
