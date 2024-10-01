using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.Migrations
{
    /// <inheritdoc />
    public partial class FixerrormodelComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Blogs_BlogId1",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "BlogId1",
                table: "Comments",
                newName: "BlogsId1");

            migrationBuilder.RenameColumn(
                name: "BlogId",
                table: "Comments",
                newName: "BlogsId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_BlogId1",
                table: "Comments",
                newName: "IX_Comments_BlogsId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Blogs_BlogsId1",
                table: "Comments",
                column: "BlogsId1",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Blogs_BlogsId1",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "BlogsId1",
                table: "Comments",
                newName: "BlogId1");

            migrationBuilder.RenameColumn(
                name: "BlogsId",
                table: "Comments",
                newName: "BlogId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_BlogsId1",
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
    }
}
