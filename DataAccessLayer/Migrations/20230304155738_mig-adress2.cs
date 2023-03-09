using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migadress2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Adresses",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Adresses",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "4ca4e2b654894f4db57685007068d6be", "37faeb21348abc0c4ea7d4dea94f06320d3e70d967bf628514e755a470c220690232c08503bd6edcd8adbdc23dc9dcd7e2540763ab2fc895a6bfc1aa74235ae6", "0ecefd57e8f647f39c807af4280409d83/4/202365738PM" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Adresses");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Adresses");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "7974078390b0458eb3a84d850a6212ee", "7e3d378ba830156f55f25af0f800848356c52a58295174cbb81ccad30aa1c017a7e9c57e4140426b60c485d724e5ad67eaa1c99afa167a20005ed1ac675f9e14", "14cd0d4856ae489da72c11498b4f47193/4/202365611PM" });
        }
    }
}
