using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IceCreamShopDatabaseImplement.Migrations
{
    /// <inheritdoc />
    public partial class AddShopMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxCountIceCreams = table.Column<int>(type: "int", nullable: false),
                    DateOpen = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShopIceCreams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopId = table.Column<int>(type: "int", nullable: false),
                    IceCreamId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopIceCreams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopIceCreams_IceCreams_IceCreamId",
                        column: x => x.IceCreamId,
                        principalTable: "IceCreams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopIceCreams_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopIceCreams_IceCreamId",
                table: "ShopIceCreams",
                column: "IceCreamId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopIceCreams_ShopId",
                table: "ShopIceCreams",
                column: "ShopId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopIceCreams");

            migrationBuilder.DropTable(
                name: "Shops");
        }
    }
}
