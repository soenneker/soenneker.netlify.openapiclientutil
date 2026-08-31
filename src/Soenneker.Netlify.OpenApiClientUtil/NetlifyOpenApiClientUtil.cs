using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.Netlify.HttpClients.Abstract;
using Soenneker.Netlify.OpenApiClientUtil.Abstract;
using Soenneker.Netlify.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Netlify.OpenApiClientUtil;

public sealed class NetlifyOpenApiClientUtil : INetlifyOpenApiClientUtil
{
    private readonly AsyncSingleton<NetlifyOpenApiClient> _client;

    public NetlifyOpenApiClientUtil(INetlifyOpenApiHttpClient httpClientUtil)
    {
        _client = new AsyncSingleton<NetlifyOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient);

            return new NetlifyOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<NetlifyOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
