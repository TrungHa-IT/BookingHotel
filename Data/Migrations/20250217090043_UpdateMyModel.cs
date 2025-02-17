using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMyModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExtrasId",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Extras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extras", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ExtrasId",
                table: "Bookings",
                column: "ExtrasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Extras_ExtrasId",
                table: "Bookings",
                column: "ExtrasId",
                principalTable: "Extras",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Extras_ExtrasId",
                table: "Bookings");

            migrationBuilder.DropTable(
                name: "Extras");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_ExtrasId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ExtrasId",
                table: "Bookings");
        }
    }
}
