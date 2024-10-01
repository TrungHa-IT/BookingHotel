using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.Migrations
{
    /// <inheritdoc />
    public partial class UpdatemodelBlogv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Blogs_BlogsId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "BlogsId",
                table: "Comments",
                newName: "BlogId1");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_BlogsId",
                table: "Comments",
                newName: "IX_Comments_BlogId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Blogs_BlogId1",
                table: "Comments",
                column: "BlogId1",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Blogs_BlogId1",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "BlogId1",
                table: "Comments",
                newName: "BlogsId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_BlogId1",
                table: "Comments",
                newName: "IX_Comments_BlogsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Blogs_BlogsId",
                table: "Comments",
                column: "BlogsId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
