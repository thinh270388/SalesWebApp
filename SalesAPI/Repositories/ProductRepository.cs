using Microsoft.EntityFrameworkCore;
using Polly;
using SalesAPI.Data;
using SalesAPI.Entities;

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
            await _context.Products.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<Product> Delete(Product model)
        {
            _context.Products.Remove(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetById(Product model)
        {
            var data = await _context.Products.FindAsync(model);
            return data!;
        }

        public async Task<Product> Update(Product model)
        {
            _context.Products.Update(model);
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
