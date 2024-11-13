using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRoomFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxAdultPeople",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxChildrenPeople",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxAdultPeople",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "MaxChildrenPeople",
                table: "Rooms");
        }
    }
}
