using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migadress3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Adresses",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "3f5f1e005be54a43bb82dd0fd73c54e2", "70d65ccdc25919b50698ebf05f2864791cd80c56afebba642994c8a42a3700910eb09f32fce56389e84b966498420a55f6ee032b3ba20e5dd5ab5c6da2de54e1", "9eca5d7fe06c440f943b921ecab5e2d63/6/202331247PM" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Adresses");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "4ca4e2b654894f4db57685007068d6be", "37faeb21348abc0c4ea7d4dea94f06320d3e70d967bf628514e755a470c220690232c08503bd6edcd8adbdc23dc9dcd7e2540763ab2fc895a6bfc1aa74235ae6", "0ecefd57e8f647f39c807af4280409d83/4/202365738PM" });
        }
    }
}
