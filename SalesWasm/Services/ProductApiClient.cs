using SalesModels;
using System.Net.Http.Json;

namespace SalesWasm.Services
{
    public class ProductApiClient : IProductApiClient
    {
        HttpClient _httpClient;

        public ProductApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductDto>> GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ProductDto>>("/api/products");
            return result!;
        }

        public async Task<ProductDto> GetById(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<ProductDto>($"/api/products/{id}");
            return result!;
        }
    }
}
