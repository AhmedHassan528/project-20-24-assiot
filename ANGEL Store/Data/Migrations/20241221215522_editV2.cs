using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ANGEL_Store.Migrations
{
    /// <inheritdoc />
    public partial class editV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardPro_Order_OrderId",
                schema: "dbo",
                table: "CardPro");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_CardPro_OrderId",
                schema: "dbo",
                table: "CardPro");

            migrationBuilder.DropColumn(
                name: "OrderId",
                schema: "dbo",
                table: "CardPro");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                schema: "dbo",
                table: "CardPro",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "dbo",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cardProCardId = table.Column<int>(type: "int", nullable: true),
                    locationAddressId = table.Column<int>(type: "int", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressID = table.Column<int>(type: "int", nullable: false),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ItemID = table.Column<int>(type: "int", nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QTY = table.Column<int>(type: "int", nullable: false),
                    SecPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelectedColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelectedPaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelectedSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusNow = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_CardPro_cardProCardId",
                        column: x => x.cardProCardId,
                        principalSchema: "dbo",
                        principalTable: "CardPro",
                        principalColumn: "CardId");
                    table.ForeignKey(
                        name: "FK_Order_Location_locationAddressId",
                        column: x => x.locationAddressId,
                        principalSchema: "dbo",
                        principalTable: "Location",
                        principalColumn: "AddressId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardPro_OrderId",
                schema: "dbo",
                table: "CardPro",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_cardProCardId",
                schema: "dbo",
                table: "Order",
                column: "cardProCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_locationAddressId",
                schema: "dbo",
                table: "Order",
                column: "locationAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_CardPro_Order_OrderId",
                schema: "dbo",
                table: "CardPro",
                column: "OrderId",
                principalSchema: "dbo",
                principalTable: "Order",
                principalColumn: "OrderId");
        }
    }
}
