using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TH_WEB_4_UP.Models;
using TH_WEB_4_UP.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddControllersWithViews();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
 .AddEntityFrameworkStores<ApplicationDbContext>()
 .AddDefaultTokenProviders()
 .AddDefaultUI();

builder.Services.AddRazorPages();

builder.Services.AddScoped<IProductRepository, EFProductRepository>();
builder.Services.AddScoped<ICategoryRepository, EFCategoryRepository>();

// Cấu hình Authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole(SD.Role_Admin));
    options.AddPolicy("ViewOnly", policy => 
        policy.RequireRole(SD.Role_Customer, SD.Role_Company, SD.Role_Employee));
});

// Cấu hình đường dẫn Identity
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
    options.LogoutPath = "/Identity/Account/Logout";
    options.AccessDeniedPath = "/Shared/AccessDenied";
});

var app = builder.Build();

// Seed the database with categories
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var categoryRepository = services.GetRequiredService<ICategoryRepository>();
    await categoryRepository.SeedCategoriesAsync();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseSession();

app.UseRouting();

app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

// Ensure these methods are defined and imported correctly
app.MapStaticAssets();
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages();
app.Run();
