using Soenneker.Netlify.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Netlify.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class NetlifyOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly INetlifyOpenApiClientUtil _openapiclientutil;

    public NetlifyOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<INetlifyOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
