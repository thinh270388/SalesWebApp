using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SalesAPI.Data;
using SalesAPI.Entities;
using SalesAPI.Extensions;
using SalesAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Đăng ký DbContext
builder.Services.AddDbContext<SalesDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Dăng kí Controllers
builder.Services.AddControllers();

// Đăng ký Cors (Chính sách bảo mật, định nghĩa các kết nối được phép vào)
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

// Đăng ký Identity
builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<SalesDbContext>().AddDefaultTokenProviders();

// Đăng ký Repository (Life cirle: Transient, Scoped, Singleton)
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<ICategorytRepository, CategoryRepository>();

var app = builder.Build();

// Chạy SeedAsync khi khởi động (Khởi tạo Data)
app.MigrateDbContext<SalesDbContext>((context, services) =>
{
    var logger = services.GetService<ILogger<SalesDbContextSeed>>()!;
    new SalesDbContextSeed().SeedAsync(context, logger).Wait();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.MapControllers();

app.UseRouting();

app.Run();