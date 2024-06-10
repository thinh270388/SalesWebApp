using SalesModels;

namespace SalesWasm.Services
{
    public interface IProductApiClient
    {
        Task<List<ProductDto>> GetAll();

        Task<ProductDto> GetById(string id);
    }
}
