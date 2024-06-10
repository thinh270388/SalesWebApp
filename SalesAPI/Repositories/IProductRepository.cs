using SalesAPI.Entities;
using System.Numerics;

namespace SalesAPI.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();

        Task<Product> GetById(Guid id);

        Task<Product> Create(Product model);

        Task<Product> Update(Product model);

        Task Delete(Guid id);
    }
}
