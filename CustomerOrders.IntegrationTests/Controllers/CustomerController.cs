using CustomerOrders.API.DTOs;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrders.IntegrationTests.Controllers
{
    public class CustomerController : IClassFixture<CustomWebApplicationFactory<Program>>, IDisposable
    {
        private HttpClient _httpClient;

        public CustomerController(CustomWebApplicationFactory<Program> _applicationFactory)
        {
            _httpClient = _applicationFactory.CreateClient();
        }
        [Fact]
        public async Task Get_Always_ReturnAllProducts()
        {
            var response = await _httpClient.GetAsync("api/customer");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }
       
        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
