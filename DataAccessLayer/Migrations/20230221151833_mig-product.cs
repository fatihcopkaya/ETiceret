using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Contents",
                table: "Products",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "d8465a4133224ea2a8ce78353875f84a", "36d24cbebce213371a80d8af18c2f324b34c7492a904a8535d961d0fcfeb16827621bf62a777d56807e19a4e85d1e48308d164bee941a8e6b0d773a0c0c65f75", "f02a61023997444c8499b1e55712d39b2/21/202361833PM" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Contents",
                keyValue: null,
                column: "Contents",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Contents",
                table: "Products",
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
                values: new object[] { "02a7d7c12a8e43e988b2b52f3ac7d600", "683b17886b55f97bfef08df4a3d21020c06114a48eff4d4c914d23467b12553dc128fcdcff11e5cc0d2c220f70102be338750964f520d27cdf87a684da72c561", "36a1265ef32041479aa7755771784e3c2/21/202361135PM" });
        }
    }
}
