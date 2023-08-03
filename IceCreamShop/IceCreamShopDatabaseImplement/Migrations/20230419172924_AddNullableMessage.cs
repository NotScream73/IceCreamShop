using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IceCreamShopDatabaseImplement.Migrations
{
    /// <inheritdoc />
    public partial class AddNullableMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageInfos_Clients_ClientId",
                table: "MessageInfos");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "MessageInfos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MessageInfos_Clients_ClientId",
                table: "MessageInfos",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageInfos_Clients_ClientId",
                table: "MessageInfos");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "MessageInfos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageInfos_Clients_ClientId",
                table: "MessageInfos",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
