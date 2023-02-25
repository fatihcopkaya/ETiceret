using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migpr1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductPhotos_ProductId",
                table: "ProductPhotos");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "71270aac9b0f41a2bdbba689bed5adff", "1b3298e7078ae7fcbec557c5d3f10ca62fe4e75c5c147f3f5ee70d03599132d846832daa547ff63fb2c64e5cf71ea00f915352b45ce362faf1dce31d1b4e59d7", "b5b5175de04a4351b5388876ea45f0102/25/202341948PM" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductPhotos_ProductId",
                table: "ProductPhotos",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductPhotos_ProductId",
                table: "ProductPhotos");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "6bbfcb8a259f44bca7d91a25020c193a", "5d54d0106934af85f53dc5b7b51e19a260b7ba4fa53cd1e07afb4cd0b4fa94f6ad100c0f77d11c50f279af332387606cc5d3b0b6ba7abbe6a615cfa01820dba1", "2ab686a0f2ff4ce1b4e146dc8ab954242/25/202341811PM" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductPhotos_ProductId",
                table: "ProductPhotos",
                column: "ProductId",
                unique: true);
        }
    }
}
