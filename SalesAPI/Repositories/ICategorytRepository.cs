using SalesAPI.Entities;
using System.Numerics;

namespace SalesAPI.Repositories
{
    public interface ICategorytRepository
    {
        Task<List<Category>> GetAll();

        Task<Category> GetById(Guid id);

        Task<Category> Create(Category model);

        Task<Category> Update(Category model);

        Task Delete(Guid id);
    }
}
