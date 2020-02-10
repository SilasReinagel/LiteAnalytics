using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace LiteAnalytics.Tests.AcceptanceTests
{
    public class BasicApiTests
    {
        [Fact]
        public async Task StatusEndpoint_HttpStatusCodeOk()
        {
            var response = await TestHost.Client.GetAsync("status");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}