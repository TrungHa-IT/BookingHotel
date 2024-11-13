using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelVoucherv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rooms_VoucherId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_voucherID",
                table: "Bookings");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_VoucherId",
                table: "Rooms",
                column: "VoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_voucherID",
                table: "Bookings",
                column: "voucherID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Rooms_VoucherId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_voucherID",
                table: "Bookings");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_VoucherId",
                table: "Rooms",
                column: "VoucherId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_voucherID",
                table: "Bookings",
                column: "voucherID",
                unique: true);
        }
    }
}
