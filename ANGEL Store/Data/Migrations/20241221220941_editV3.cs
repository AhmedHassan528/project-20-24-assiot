using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ANGEL_Store.Migrations
{
    /// <inheritdoc />
    public partial class editV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemImage2",
                schema: "dbo",
                table: "CardPro");

            migrationBuilder.DropColumn(
                name: "ItemImage3",
                schema: "dbo",
                table: "CardPro");

            migrationBuilder.DropColumn(
                name: "ItemImage4",
                schema: "dbo",
                table: "CardPro");

            migrationBuilder.DropColumn(
                name: "logoid",
                schema: "dbo",
                table: "CardPro");

            migrationBuilder.DropColumn(
                name: "selectLogoLoc",
                schema: "dbo",
                table: "CardPro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ItemImage2",
                schema: "dbo",
                table: "CardPro",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemImage3",
                schema: "dbo",
                table: "CardPro",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemImage4",
                schema: "dbo",
                table: "CardPro",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "logoid",
                schema: "dbo",
                table: "CardPro",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "selectLogoLoc",
                schema: "dbo",
                table: "CardPro",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
