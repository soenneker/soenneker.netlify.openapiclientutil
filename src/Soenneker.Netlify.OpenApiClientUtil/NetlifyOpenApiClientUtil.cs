using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.Netlify.HttpClients.Abstract;
using Soenneker.Netlify.OpenApiClientUtil.Abstract;
using Soenneker.Netlify.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Netlify.OpenApiClientUtil;

///<inheritdoc cref="INetlifyOpenApiClientUtil"/>
public sealed class NetlifyOpenApiClientUtil : INetlifyOpenApiClientUtil
{
    private readonly AsyncSingleton<NetlifyOpenApiClient> _client;

    public NetlifyOpenApiClientUtil(INetlifyOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<NetlifyOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("Netlify:ApiKey");
            string authHeaderValueTemplate = configuration["Netlify:AuthHeaderValueTemplate"] ?? "Bearer {token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerValue: authHeaderValue), httpClient: httpClient);

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
