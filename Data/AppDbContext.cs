using HotelBooking.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Categories> Categories { get; set; } = default!;
        public DbSet<Blog> Blogs { get; set; } = default!;
        public DbSet<Comments> Comments { get; set; } = default!;
        public DbSet<Service> Services { get; set; } = default!;
        public DbSet<ServiceCategories> ServiceCategories { get; set; } = default!;
        public DbSet<Image> Images { get; set; } = default!;
        public DbSet<BookingService> BookingServices { get; set; } = default!;
        public DbSet<Booking> Bookings { get; set; } = default!;
        public DbSet<Voucher> Vouchers { get; set; } = default!;
        public DbSet<Room> Rooms { get; set; } = default!;
        public DbSet<CategoriesRoom> CategoriesRooms { get; set; } = default!;
        public DbSet<AppUser> AppUsers { get; set; } = default!;
        public DbSet<Feedback> Feedbacks { get; set; } = default!;
        public DbSet<Payment> Payments { get; set; } = default!;
        public DbSet<Extras> Extras { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình quan hệ giữa Booking và BookAble (một Booking có nhiều BookAbles)
            modelBuilder.Entity<BookAble>()
                .HasOne(ba => ba.Booking)
                .WithMany(b => b.BookAbles)
                .HasForeignKey(ba => ba.BookingId)
                .OnDelete(DeleteBehavior.Restrict);  // Không cascade delete khi xóa Booking

            // Cấu hình quan hệ giữa Room và BookAble (một Room có nhiều BookAbles)
            modelBuilder.Entity<BookAble>()
                .HasOne(ba => ba.Room)
                .WithMany(r => r.BookAbles)
                .HasForeignKey(ba => ba.RoomId)
                .OnDelete(DeleteBehavior.Restrict);  // Không cascade delete khi xóa Room
        }
    }

}
