using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelBlog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Blogs_BlogsId1",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "BlogsId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "BlogsId1",
                table: "Comments",
                newName: "BlogId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_BlogsId1",
                table: "Comments",
                newName: "IX_Comments_BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Blogs_BlogId",
                table: "Comments",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Blogs_BlogId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "BlogId",
                table: "Comments",
                newName: "BlogsId1");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_BlogId",
                table: "Comments",
                newName: "IX_Comments_BlogsId1");

            migrationBuilder.AddColumn<string>(
                name: "BlogsId",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Blogs_BlogsId1",
                table: "Comments",
                column: "BlogsId1",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
