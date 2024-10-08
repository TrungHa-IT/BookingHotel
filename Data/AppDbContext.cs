using HotelBooking.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Data
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        }
        public DbSet<HotelBooking.Models.Categories> Categories { get; set; } = default!;
        public DbSet<HotelBooking.Models.Roles> Roles { get; set; } = default!;
        public DbSet<Blog> Blogs { get; set; } = default!;
        public DbSet<Comments> Comments { get; set; } = default!;
        public DbSet<Service> Services { get; set; } = default!;
        public DbSet<ServiceCategories> ServiceCategories { get; set; } = default!;
        public DbSet<Image> Images { get; set; } = default!;
        public DbSet<UsingType> UsingTypes { get; set; } = default!;
        public DbSet<UsingImage> UsingImage { get; set; } = default!;
        public DbSet<BookingService> BookingServices { get; set; } = default!;
    }
}
