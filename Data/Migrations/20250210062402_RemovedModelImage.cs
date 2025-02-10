using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedModelImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsingImage");

            migrationBuilder.DropTable(
                name: "UsingTypes");

            migrationBuilder.AddColumn<int>(
                name: "RID",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RID",
                table: "Images");

            migrationBuilder.CreateTable(
                name: "UsingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsingImage",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageID = table.Column<int>(type: "int", nullable: false),
                    TypeID = table.Column<int>(type: "int", nullable: false),
                    RID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsingImage", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UsingImage_Images_ImageID",
                        column: x => x.ImageID,
                        principalTable: "Images",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsingImage_UsingTypes_TypeID",
                        column: x => x.TypeID,
                        principalTable: "UsingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsingImage_ImageID",
                table: "UsingImage",
                column: "ImageID");

            migrationBuilder.CreateIndex(
                name: "IX_UsingImage_TypeID",
                table: "UsingImage",
                column: "TypeID");
        }
    }
}
