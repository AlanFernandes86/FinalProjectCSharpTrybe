using FinalProjectCSharpTrybe.Models;
using FinalProjectCSharpTrybe.Services;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http.Headers;
using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using FluentAssertions;

namespace FinalProjectCSharpTrybe.test
{
    public class PostControllerTest
    {
        private readonly WebApplicationFactory<Program> _factory;
        private const string controllerName = "user";

        public PostControllerTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        public async Task TestPost()
        {
           
        }
    }
}