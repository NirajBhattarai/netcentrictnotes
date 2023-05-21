using BethanysPieShop.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

//builder.Services.AddScoped<ICategoryRepository, MockCategoryRepository>();
//builder.Services.AddScoped<IPieRepository, MockPieRepository>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();


builder.Services.AddDbContext<BethanysPieShopDbContext>(options => {
    options.UseNpgsql(
        builder.Configuration["ConnectionStrings:BethanysPieShopDbContextConnection"]);
});

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.MapDefaultControllerRoute();

DbInitializer.Seed(app);

app.Run();
