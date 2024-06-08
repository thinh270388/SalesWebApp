using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SalesAPI.Entities;

namespace SalesAPI.Data
{
    public class SalesDbContext : IdentityDbContext<User>
    {
        public SalesDbContext(DbContextOptions<SalesDbContext> options) : base(options) 
        { 

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
