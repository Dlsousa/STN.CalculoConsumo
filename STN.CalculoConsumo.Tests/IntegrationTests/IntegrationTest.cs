using FluentAssertions;
using STN.CalculoConsumo.Tests.Fixtures;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace STN.CalculoConsumo.Tests.IntegrationTests
{
    public class IntegrationTest
    {
        private readonly TestContext _testContext;

        public IntegrationTest()
        {
            _testContext = new TestContext();
        }
    
        [Fact]
        public async Task Values_Post_ReturnsOkResponse()
        {
            var content = new StringContent(string.Empty, Encoding.UTF8, "application/json");
            var response = await _testContext.Client.PostAsync("api/v1/CalculoConsumo", content);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
