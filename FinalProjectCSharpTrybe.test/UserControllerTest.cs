using FinalProjectCSharpTrybe.Models;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;
using System.Net.Http.Json;

namespace FinalProjectCSharpTrybe.test
{
    public class UserControllerTest
    {
        private readonly WebApplicationFactory<Program> _factory;
        private const string controllerName = "user";

        public UserControllerTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Theory(DisplayName = "Teste para PlataformWelcome com Status Ok")]
        [InlineData("Luiz", "luiz@home.com", "back-end", 0, "123456")]
        [InlineData("Miguel", "miguel@home.com", "front-end", 0, "12345678")]
        public async Task TestCreateNewUser(string name, string email, string module, int status, string password)
        {
            User testUser = new() 
            {
                Name = name,
                Email = email,
                Module = module,
                Status = status,
                Password = password,
            };

            var client = _factory.CreateClient();

            // var token = new TokenGenerator().Generate(testUser);

            // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.PostAsJsonAsync("User", testUser);

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}