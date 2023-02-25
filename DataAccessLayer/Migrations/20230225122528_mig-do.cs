using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migdo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "Users",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Documents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "5659ec4f768e489ebc42d7f95630ea94", "015e30d0866d598945b5e46903c800cbe4111155af0d718a074d762e2ff7e8f7743ab222d1423fef76975f70474128a2011460ef8656e37e065f1a6aae3d9147", "7178d7d6b9584259b32e495c957ccd362/25/202332528PM" });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ProductId",
                table: "Documents",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Products_ProductId",
                table: "Documents",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Products_ProductId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_ProductId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Documents");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Token",
                keyValue: null,
                column: "Token",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "Users",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "342a4fbe0d784af1bf093cb8a8f9356a", "de1c3c1dd179ec182a8b69a21fae8d846dac92a67a0918c76726e2130be79fda2b93c66ca309c493d0b8be15161982982bcb21ed36660a8dad91ff6447af6de9", "70e2418e494e4517b999cc087fa5bcce2/22/2023115658PM" });
        }
    }
}
