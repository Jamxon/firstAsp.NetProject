using firstAsp.NetProject.Data;
using firstAsp.NetProject.Repositories;
using firstAsp.NetProject.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddTransient<ApplicationDbContext>();
builder.Services.AddTransient<IProductRepositiory, ProductRepository>();
builder.Services.AddTransient<IProductService, ProductService>();

var app = builder.Build();

app.MapControllers();
app.Run();