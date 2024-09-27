using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineStore.Entities.Interfaces.IRepositries;
using OnlineStore.Entities.Interfaces.IServices;
using OnlineStore.Entities.Models.Authentication;
using OnlineStore.Infrastructure;
using OnlineStore.Infrastructure.Repositories;
using OnlineStore.Services;

//using OnlineStore.Infrastructure.DataContext;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("default")) 
);

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddIdentity<User,IdentityRole<int>>(options =>
            options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IBidRepository, BidRepository>();


builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<CountryService>();
builder.Services.AddScoped<BidService>();
builder.Services.AddRazorPages();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = new PathString("/Identity/Account/Login");
    options.AccessDeniedPath = new PathString("/Identity/Account/AccessDenied");
    //other properties
});

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

app.UseAuthentication();
app.UseAuthorization();

/*
 * user1 has role UserRole
 *      UserRole can use
 *          Auction.Create
 *          Auction.Delete
 *          Aution.Edit
 *  user2 has Role  AdminRole
 *      AdminRole can use
 *          Users.Index
 *          Users.Delete
 *          
 *  
 */

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
