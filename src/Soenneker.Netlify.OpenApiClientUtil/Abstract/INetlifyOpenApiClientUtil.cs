using Soenneker.Netlify.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Netlify.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface INetlifyOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<NetlifyOpenApiClient> Get(CancellationToken cancellationToken = default);
}
