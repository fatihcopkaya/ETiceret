using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migorder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offer_Products_ProductId",
                table: "Offer");

            migrationBuilder.DropForeignKey(
                name: "FK_Offer_Users_UserId",
                table: "Offer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Offer",
                table: "Offer");

            migrationBuilder.RenameTable(
                name: "Offer",
                newName: "Offers");

            migrationBuilder.RenameIndex(
                name: "IX_Offer_UserId",
                table: "Offers",
                newName: "IX_Offers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Offer_ProductId",
                table: "Offers",
                newName: "IX_Offers_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Offers",
                table: "Offers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AdressId = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsActived = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    GuId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Adresses_AdressId",
                        column: x => x.AdressId,
                        principalTable: "Adresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "c41a2ccc8ab942d6ad6e2688aff4e4da", "f71f10798fd95b331526bc99cdb81251aebe57914ae35f8be385a2e0310490e28fdad47e7d02ef369603fdbc10b661811ddbaef59d708d70ee35b80978a3c15c", "f5a177b46a5d460a99f6920afd55e5d53/11/202360531PM" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AdressId",
                table: "Orders",
                column: "AdressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartId",
                table: "Orders",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Products_ProductId",
                table: "Offers",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Users_UserId",
                table: "Offers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Products_ProductId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Users_UserId",
                table: "Offers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Offers",
                table: "Offers");

            migrationBuilder.RenameTable(
                name: "Offers",
                newName: "Offer");

            migrationBuilder.RenameIndex(
                name: "IX_Offers_UserId",
                table: "Offer",
                newName: "IX_Offer_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Offers_ProductId",
                table: "Offer",
                newName: "IX_Offer_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Offer",
                table: "Offer",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "e71631d00f5a4407a0cba44242d44676", "0c82003d7acc2653b2b6495f2e113991a35a75f44de9573ce634110eace34e18bb554c0f8abc61c73f6c0241e097ca134d1d996a9b45b7c982e16dafa22197b0", "11fd462ef3f044bf8a829c44aeebf0f53/9/202342659PM" });

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_Products_ProductId",
                table: "Offer",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_Users_UserId",
                table: "Offer",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
