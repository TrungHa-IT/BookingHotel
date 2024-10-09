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
        public DbSet<Blog> Blogs { get; set; } = default!;
        public DbSet<Comments> Comments { get; set; } = default!;
        public DbSet<Service> Services { get; set; } = default!;
        public DbSet<ServiceCategories> ServiceCategories { get; set; } = default!;
        public DbSet<Image> Images { get; set; } = default!;
        public DbSet<UsingType> UsingTypes { get; set; } = default!;
        public DbSet<UsingImage> UsingImage { get; set; } = default!;
        public DbSet<BookingService> BookingServices { get; set; } = default!;
        public DbSet<Booking> Bookings { get; set; } = default!;
        public DbSet<BookingDetail> BookingDetails { get; set; } = default!;
        public DbSet<Voucher> Vouchers { get; set; } = default!;
        public DbSet<Room> Rooms { get; set; } = default!;
        public DbSet<CategoriesRoom> CategoriesRooms { get; set; } = default!;
        public DbSet<AppUser> AppUsers { get; set; } = default!;
        public DbSet<Feedback> Feedbacks { get; set; } = default!;
        public DbSet<Payment> Payments { get; set; } = default!;
    }
}
