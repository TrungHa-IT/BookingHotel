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
    }
}
