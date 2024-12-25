using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ANGEL_Store.Migrations
{
    /// <inheritdoc />
    public partial class editv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardPro_CustomItemAdmin_CustomItemAdminId",
                schema: "dbo",
                table: "CardPro");

            migrationBuilder.DropForeignKey(
                name: "FK_CardPro_Logo_logoid",
                schema: "dbo",
                table: "CardPro");

            migrationBuilder.DropTable(
                name: "CustomItem",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CustomItemAdmin",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Logo",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_CardPro_CustomItemAdminId",
                schema: "dbo",
                table: "CardPro");

            migrationBuilder.DropIndex(
                name: "IX_CardPro_logoid",
                schema: "dbo",
                table: "CardPro");

            migrationBuilder.DropColumn(
                name: "CustomItemAdminId",
                schema: "dbo",
                table: "CardPro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomItemAdminId",
                schema: "dbo",
                table: "CardPro",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CustomItem",
                schema: "dbo",
                columns: table => new
                {
                    CustomItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CusQTY = table.Column<int>(type: "int", nullable: false),
                    ItemImage1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemImage2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemImage3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemImage4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SelectedColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelectedLogoLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelectedSize = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomItem", x => x.CustomItemId);
                });

            migrationBuilder.CreateTable(
                name: "CustomItemAdmin",
                schema: "dbo",
                columns: table => new
                {
                    CustomItemAdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Colorlist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemImage1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemImage2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemImage3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemImage4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ItemPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ItemQuantity = table.Column<int>(type: "int", nullable: false),
                    LogoLocationList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelectedLogoId = table.Column<int>(type: "int", nullable: true),
                    Sizelist = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomItemAdmin", x => x.CustomItemAdminId);
                });

            migrationBuilder.CreateTable(
                name: "Logo",
                schema: "dbo",
                columns: table => new
                {
                    logoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogoImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    logoName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logo", x => x.logoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardPro_CustomItemAdminId",
                schema: "dbo",
                table: "CardPro",
                column: "CustomItemAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_CardPro_logoid",
                schema: "dbo",
                table: "CardPro",
                column: "logoid");

            migrationBuilder.AddForeignKey(
                name: "FK_CardPro_CustomItemAdmin_CustomItemAdminId",
                schema: "dbo",
                table: "CardPro",
                column: "CustomItemAdminId",
                principalSchema: "dbo",
                principalTable: "CustomItemAdmin",
                principalColumn: "CustomItemAdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_CardPro_Logo_logoid",
                schema: "dbo",
                table: "CardPro",
                column: "logoid",
                principalSchema: "dbo",
                principalTable: "Logo",
                principalColumn: "logoId");
        }
    }
}
