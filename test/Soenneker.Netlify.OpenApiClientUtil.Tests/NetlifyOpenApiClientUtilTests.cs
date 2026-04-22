using Soenneker.Netlify.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Netlify.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class NetlifyOpenApiClientUtilTests : HostedUnitTest
{
    private readonly INetlifyOpenApiClientUtil _openapiclientutil;

    public NetlifyOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<INetlifyOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
