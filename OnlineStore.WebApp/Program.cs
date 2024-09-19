using Microsoft.EntityFrameworkCore;
using OnlineStore.Entities.Interfaces.IRepositries;
using OnlineStore.Entities.Interfaces.IServices;
using OnlineStore.Infrastructure;
using OnlineStore.Infrastructure.Repositories;
using OnlineStore.Services;

//using OnlineStore.Infrastructure.DataContext;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("default"))
);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();


builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IItemService, ItemService>();    


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
