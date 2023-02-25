using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migdoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "aead14814ed24a4ab4ecfa2dc4aad59a", "f452802145f3ed475fa6f07525b56cd16251b3e9950889e644473de627e92f008b95662c5e7e432c0bde4a9b1cee5a514c20020b734d884f70f522d159b23020", "d56aaf4de34b42b096f1ddca76b42ba92/25/202333703PM" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
