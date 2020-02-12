using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Xunit;

namespace LiteAnalytics.Tests.AcceptanceTests
{
    public sealed class AdministerPropertyTests
    {
        [Fact]
        public async Task CreateProperty_IdAssigned()
        {
            var baseUrl = "https://localhost:8080";
            var client = TestHost.Client;

            var queryString = $"?url={HttpUtility.UrlEncode("https://www.google.com")}";
            var resp = await client.SendAsync(new HttpRequestMessage(HttpMethod.Put, $"{baseUrl}/api/property{queryString}"));
            Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
            
            var bodyJson = await resp.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<PropertyResponse>(bodyJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            Assert.False(string.IsNullOrWhiteSpace(response.Id));
        }

        private class PropertyResponse
        {
            public string Id { get; set; }
        }
    }
}
