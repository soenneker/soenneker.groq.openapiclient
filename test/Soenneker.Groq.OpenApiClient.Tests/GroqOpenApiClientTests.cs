using Soenneker.Tests.HostedUnit;

namespace Soenneker.Groq.OpenApiClient.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class GroqOpenApiClientTests : HostedUnitTest
{
    public GroqOpenApiClientTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}
