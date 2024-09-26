using HotelBooking.Data;
using HotelBooking.Models;
using HotelBooking.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure Google Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
.AddCookie() // Adds cookie authentication
.AddGoogle(GoogleDefaults.AuthenticationScheme, options =>
{
    options.ClientId = builder.Configuration.GetSection("GoogleKeys:ClientID").Value;
    options.ClientSecret = builder.Configuration.GetSection("GoogleKeys:ClientSecret").Value;
});


// Configure the database connection
var connectionString = builder.Configuration.GetConnectionString("default");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

// Đăng ký Repository
builder.Services.AddScoped<ICategoriesRepositories, CategoriesRepository>();
builder.Services.AddScoped<ICommentsRepositories, CommentsRepositories>();
builder.Services.AddScoped<IBlogRepositories, BlogRepositories>();
builder.Services.AddScoped<IRoleRepositories, RoleRepositories>();
builder.Services.AddTransient<UnitOfWork>();
// Add ASP.NET Core Identity services
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 8; // Password requirements
})
.AddEntityFrameworkStores<AppDbContext>() // Use Entity Framework Core for data storage
.AddDefaultTokenProviders();

builder.Services.AddControllersWithViews(); // Add MVC services

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Handle errors in production
    app.UseHsts(); // Use HSTS for enhanced security
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Add authentication and authorization middleware
app.UseAuthentication(); // Add this line to enable authentication
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=index}/{id?}");

// Run the application
app.Run();
