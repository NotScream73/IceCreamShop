using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IceCreamShopDatabaseImplement.Migrations
{
    /// <inheritdoc />
    public partial class Order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Orders_IceCreamId",
                table: "Orders",
                column: "IceCreamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_IceCreams_IceCreamId",
                table: "Orders",
                column: "IceCreamId",
                principalTable: "IceCreams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_IceCreams_IceCreamId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_IceCreamId",
                table: "Orders");
        }
    }
}
