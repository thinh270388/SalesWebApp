using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Polly;
using SalesAPI.Data;
using SalesAPI.Entities;
using System.Linq;

namespace SalesAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SalesDbContext _context;

        public ProductRepository(SalesDbContext context)
        { 
            _context = context;
        }
        public async Task<Product> Create(Product model)
        {
            _context.Products.Add(model);
            await _context.SaveChangesAsync();

            var result = await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == model.Id);
            return result!;
        }

        public async Task Delete(Guid id)
        {
            var data = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (data != null)
            {
                _context.Products.Remove(data);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.Include(x => x.Category).ToListAsync();
        }

        public async Task<Product> GetById(Guid id)
        {
            var data = await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
            return data!;
        }

        public async Task<Product> Update(Product model)
        {
            _context.Products.Update(model);
            await _context.SaveChangesAsync();

            var result = await _context.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == model.Id);
            return result!;
        }
    }
}
