using Soenneker.Netlify.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Netlify.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides a cached Netlify API client backed by the configured HTTP provider.
/// </summary>
public interface INetlifyOpenApiClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the cached Netlify client, creating it on the first call.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The configured Netlify client.</returns>
    ValueTask<NetlifyOpenApiClient> Get(CancellationToken cancellationToken = default);
}
