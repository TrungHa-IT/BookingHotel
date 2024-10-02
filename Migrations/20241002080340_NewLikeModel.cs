using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.Migrations
{
    /// <inheritdoc />
    public partial class NewLikeModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LikeRecord",
                columns: table => new
                {
                    LikeRecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LikedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikeRecord", x => x.LikeRecordId);
                    table.ForeignKey(
                        name: "FK_LikeRecord_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LikeRecord_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "CommentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LikeRecord_CommentId",
                table: "LikeRecord",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeRecord_UserId",
                table: "LikeRecord",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LikeRecord");
        }
    }
}
