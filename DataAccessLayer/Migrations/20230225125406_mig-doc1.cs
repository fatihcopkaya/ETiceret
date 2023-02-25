using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migdoc1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Index",
                table: "ProductPhotos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "f7294569a77d41fca3906168bc52008e", "d7d19c8dee3c7aef3723bda52f67d2ff5cc5388cc310c6415c5b1a01cd126cb7c9b888d958998b67440072a6ee398b495f9719f32a01bf9fd90420aecb190f9b", "e24e134462224064a1e769a897c397e92/25/202335406PM" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Index",
                table: "ProductPhotos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "aead14814ed24a4ab4ecfa2dc4aad59a", "f452802145f3ed475fa6f07525b56cd16251b3e9950889e644473de627e92f008b95662c5e7e432c0bde4a9b1cee5a514c20020b734d884f70f522d159b23020", "d56aaf4de34b42b096f1ddca76b42ba92/25/202333703PM" });
        }
    }
}
