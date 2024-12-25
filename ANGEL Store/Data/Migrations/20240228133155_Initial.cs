using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ANGEL_Store.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    firstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "dbo",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "CustomItem",
                schema: "dbo",
                columns: table => new
                {
                    CustomItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SelectedColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelectedSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CusQTY = table.Column<int>(type: "int", nullable: false),
                    SelectedLogoLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemImage1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemImage2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemImage3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemImage4 = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    ItemName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ItemPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sizelist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Colorlist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemQuantity = table.Column<int>(type: "int", nullable: false),
                    LogoLocationList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemImage1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemImage2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemImage3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemImage4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelectedLogoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomItemAdmin", x => x.CustomItemAdminId);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                schema: "dbo",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    SecPhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "Logo",
                schema: "dbo",
                columns: table => new
                {
                    logoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    logoName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logo", x => x.logoId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                schema: "dbo",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ItemTag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Taglist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemInformation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Informationlist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ItemPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sizelist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelectedSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Colorlist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelectedColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumOfProducts = table.Column<int>(type: "int", nullable: true),
                    ItemQuantity = table.Column<int>(type: "int", nullable: false),
                    ItemStatus = table.Column<bool>(type: "bit", nullable: false),
                    ItemDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Item_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalSchema: "dbo",
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardPro",
                schema: "dbo",
                columns: table => new
                {
                    CardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemID = table.Column<int>(type: "int", nullable: true),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ItemImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelectedColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QTY = table.Column<int>(type: "int", nullable: false),
                    SelectedSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelectedPaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemImage2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemImage3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemImage4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    selectLogoLoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    logoid = table.Column<int>(type: "int", nullable: true),
                    CustomItemAdminId = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardPro", x => x.CardId);
                    table.ForeignKey(
                        name: "FK_CardPro_CustomItemAdmin_CustomItemAdminId",
                        column: x => x.CustomItemAdminId,
                        principalSchema: "dbo",
                        principalTable: "CustomItemAdmin",
                        principalColumn: "CustomItemAdminId");
                    table.ForeignKey(
                        name: "FK_CardPro_Item_ItemID",
                        column: x => x.ItemID,
                        principalSchema: "dbo",
                        principalTable: "Item",
                        principalColumn: "ItemId");
                    table.ForeignKey(
                        name: "FK_CardPro_Logo_logoid",
                        column: x => x.logoid,
                        principalSchema: "dbo",
                        principalTable: "Logo",
                        principalColumn: "logoId");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "dbo",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    AddressID = table.Column<int>(type: "int", nullable: false),
                    ItemID = table.Column<int>(type: "int", nullable: true),
                    StatusNow = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelectedPaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelectedColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QTY = table.Column<int>(type: "int", nullable: false),
                    SelectedSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cardProCardId = table.Column<int>(type: "int", nullable: true),
                    locationAddressId = table.Column<int>(type: "int", nullable: true)
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CardPro_CustomItemAdminId",
                schema: "dbo",
                table: "CardPro",
                column: "CustomItemAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_CardPro_ItemID",
                schema: "dbo",
                table: "CardPro",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_CardPro_logoid",
                schema: "dbo",
                table: "CardPro",
                column: "logoid");

            migrationBuilder.CreateIndex(
                name: "IX_CardPro_OrderId",
                schema: "dbo",
                table: "CardPro",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_CategoryID",
                schema: "dbo",
                table: "Item",
                column: "CategoryID");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardPro_CustomItemAdmin_CustomItemAdminId",
                schema: "dbo",
                table: "CardPro");

            migrationBuilder.DropForeignKey(
                name: "FK_CardPro_Item_ItemID",
                schema: "dbo",
                table: "CardPro");

            migrationBuilder.DropForeignKey(
                name: "FK_CardPro_Logo_logoid",
                schema: "dbo",
                table: "CardPro");

            migrationBuilder.DropForeignKey(
                name: "FK_CardPro_Order_OrderId",
                schema: "dbo",
                table: "CardPro");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CustomItem",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CustomItemAdmin",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Item",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Logo",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CardPro",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Location",
                schema: "dbo");
        }
    }
}
