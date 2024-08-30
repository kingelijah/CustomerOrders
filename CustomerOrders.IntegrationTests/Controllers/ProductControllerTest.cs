using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrders.IntegrationTests.Controllers
{
    public class ProductControllerTest : IClassFixture<CustomWebApplicationFactory<Program>>, IDisposable
    {
        private HttpClient _httpClient;

        public ProductControllerTest(CustomWebApplicationFactory<Program> _applicationFactory)
        {
            _httpClient = _applicationFactory.CreateClient();
        }
        [Fact]
        public async Task Get_Always_ReturnAllProducts()
        {
            var response = await _httpClient.GetAsync("api/product");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }
        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
