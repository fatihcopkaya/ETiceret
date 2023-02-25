using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migpr : Migration
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
                values: new object[] { "b4bf17b4ec4c4de593f31ecdd19cc521", "081fb8602b202f284bbaf72d15d4813bb059ce04df205dddd88ee42546c45a8bdeb4bd90647c10856e28ab32bead93aa99d1e0131321d2d63807b24001f6e961", "efd21f33f64c4adab8bfc3d9faef96562/25/202341659PM" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductPhotos_ProductId",
                table: "ProductPhotos",
                column: "ProductId",
                unique: true);
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
                values: new object[] { "f7294569a77d41fca3906168bc52008e", "d7d19c8dee3c7aef3723bda52f67d2ff5cc5388cc310c6415c5b1a01cd126cb7c9b888d958998b67440072a6ee398b495f9719f32a01bf9fd90420aecb190f9b", "e24e134462224064a1e769a897c397e92/25/202335406PM" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductPhotos_ProductId",
                table: "ProductPhotos",
                column: "ProductId");
        }
    }
}
