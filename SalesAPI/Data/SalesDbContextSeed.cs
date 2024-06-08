using Microsoft.AspNetCore.Identity;
using SalesAPI.Entities;

namespace SalesAPI.Data
{
    public class SalesDbContextSeed
    {
        private readonly IPasswordHasher<User> _passwordHasher = new PasswordHasher<User>();
        public async Task SeedAsync(SalesDbContext context, ILogger<SalesDbContextSeed> logger)
        {
            if (!context.Users.Any())
            {
                var user = new User()
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Lê",
                    LastName = "Thịnh",
                    Email = "thinh270388@gmail.com",
                    PhoneNumber = "0775426999s",
                    UserName = "admin"
                };
                user.PasswordHash = _passwordHasher.HashPassword(user, "Admin123@");
                context.Users.Add(user);
            }

            if (!context.Categories.Any())
            {
                var category = new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Vật liệu xây dựng",
                    Description = "Vật liệu"
                };
                context.Categories.Add(category);

                context.Products.Add(new Entities.Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Xi măng Hà Tiên",
                    InputPrice = 55000,
                    OutputPrice = 78000,
                    CategoryId = category.Id
                });
            }
            await context.SaveChangesAsync();
        }
    }
}
