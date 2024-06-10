using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Polly;
using SalesAPI.Data;
using SalesAPI.Entities;

namespace SalesAPI.Repositories
{
    public class CategoryRepository : ICategorytRepository
    {
        private readonly SalesDbContext _context;

        public CategoryRepository(SalesDbContext context)
        { 
            _context = context;
        }
        public async Task<Category> Create(Category model)
        {
            await _context.Categories.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task Delete(Guid id)
        {
            var data = await _context.Categories.SingleOrDefaultAsync(x => x.Id == id);
            if (data != null)
            {
                _context.Categories.Remove(data);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetById(Guid id)
        {
            var data = await _context.Categories.FindAsync(id);
            return data!;
        }

        public async Task<Category> Update(Category model)
        {
            _context.Categories.Update(model);
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
