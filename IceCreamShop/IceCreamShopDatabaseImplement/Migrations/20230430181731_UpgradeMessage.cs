using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IceCreamShopDatabaseImplement.Migrations
{
    /// <inheritdoc />
    public partial class UpgradeMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "MessageInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasRead",
                table: "MessageInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer",
                table: "MessageInfos");

            migrationBuilder.DropColumn(
                name: "HasRead",
                table: "MessageInfos");
        }
    }
}
