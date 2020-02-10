using System;
using System.Net.Http;
using LiteAnalytics.WebApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace LiteAnalytics.Tests.AcceptanceTests
{
    public static class TestHost
    {
        private static readonly Lazy<HttpClient> LazyClient = new Lazy<HttpClient>(() =>
            new TestServer(
                new WebHostBuilder()
                    .UseStartup(typeof(Startup))
            ).CreateClient());

        public static HttpClient Client => LazyClient.Value;
    }
}