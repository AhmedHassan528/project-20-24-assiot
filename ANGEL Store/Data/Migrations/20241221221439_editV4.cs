using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ANGEL_Store.Migrations
{
    /// <inheritdoc />
    public partial class editV4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardPro_Item_ItemID",
                schema: "dbo",
                table: "CardPro");

            migrationBuilder.RenameColumn(
                name: "ItemID",
                schema: "dbo",
                table: "CardPro",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_CardPro_ItemID",
                schema: "dbo",
                table: "CardPro",
                newName: "IX_CardPro_ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CardPro_Item_ItemId",
                schema: "dbo",
                table: "CardPro",
                column: "ItemId",
                principalSchema: "dbo",
                principalTable: "Item",
                principalColumn: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardPro_Item_ItemId",
                schema: "dbo",
                table: "CardPro");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                schema: "dbo",
                table: "CardPro",
                newName: "ItemID");

            migrationBuilder.RenameIndex(
                name: "IX_CardPro_ItemId",
                schema: "dbo",
                table: "CardPro",
                newName: "IX_CardPro_ItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_CardPro_Item_ItemID",
                schema: "dbo",
                table: "CardPro",
                column: "ItemID",
                principalSchema: "dbo",
                principalTable: "Item",
                principalColumn: "ItemId");
        }
    }
}
