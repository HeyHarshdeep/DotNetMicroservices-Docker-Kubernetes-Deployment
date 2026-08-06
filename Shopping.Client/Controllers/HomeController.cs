using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Shopping.Client.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace Shopping.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClient = httpClientFactory.CreateClient("ShoppingAPIClient");
        }

        public async Task<IActionResult> Index()
        {
            var response = await GetProductsResponseAsync();
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var productList = JsonSerializer.Deserialize<IEnumerable<Product>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? Enumerable.Empty<Product>();

            return View(productList);
        }

        private async Task<HttpResponseMessage> GetProductsResponseAsync()
        {
            const int maxAttempts = 5;

            for (var attempt = 1; attempt <= maxAttempts; attempt++)
            {
                try
                {
                    return await _httpClient.GetAsync("/api/product");
                }
                catch (HttpRequestException) when (attempt < maxAttempts)
                {
                    await Task.Delay(TimeSpan.FromSeconds(attempt));
                }
            }

            return await _httpClient.GetAsync("/api/product");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
