using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.Migrations
{
    /// <inheritdoc />
    public partial class Fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Inclusions",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "Services");

            migrationBuilder.RenameColumn(
                name: "Terms",
                table: "Services",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "CreateAt",
                table: "Services",
                newName: "Create_At");

            migrationBuilder.AddColumn<DateTime>(
                name: "end_time",
                table: "BookingServices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "start_time",
                table: "BookingServices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "end_time",
                table: "BookingServices");

            migrationBuilder.DropColumn(
                name: "start_time",
                table: "BookingServices");

            migrationBuilder.RenameColumn(
                name: "Create_At",
                table: "Services",
                newName: "CreateAt");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Services",
                newName: "Terms");

            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Inclusions",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
