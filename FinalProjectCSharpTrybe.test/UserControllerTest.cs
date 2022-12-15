using FinalProjectCSharpTrybe.Models;
using FinalProjectCSharpTrybe.Services;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http.Headers;
using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;

namespace FinalProjectCSharpTrybe.test
{
    public class TestUserController
    {
        private readonly WebApplicationFactory<Program> _factory;
        private const string controllerName = "user";

        public TestUserController(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Theory(DisplayName = "Teste para PlataformWelcome com Status Ok")]
        [InlineData("Mayara", false, "")]
        public async Task TestCreateNewUser(string name, bool isCompany, string currency)
        {
           User testUser = new();

            var client = _factory.CreateClient();

            var token = new TokenGenerator().Generate(testUser);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync("/Client/PlataformWelcome");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}