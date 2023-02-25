using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migdocument1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Storage_Url",
                table: "Documents");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "02a7d7c12a8e43e988b2b52f3ac7d600", "683b17886b55f97bfef08df4a3d21020c06114a48eff4d4c914d23467b12553dc128fcdcff11e5cc0d2c220f70102be338750964f520d27cdf87a684da72c561", "36a1265ef32041479aa7755771784e3c2/21/202361135PM" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Storage_Url",
                table: "Documents",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "cb4f043a8faa49d49956ca51260b663e", "d133da40666c0b3609506ec5ce1a9bbc7197370c69bbfdf2eac00f8e626e1e4e4d508bb2fdc16a6dbb2dd8e2dcb5a93e442eeaead4d6d2eb525eef06f7df98fe", "dd666cdb20394961a3676e8aaf4c9d3d2/21/202361051PM" });
        }
    }
}
