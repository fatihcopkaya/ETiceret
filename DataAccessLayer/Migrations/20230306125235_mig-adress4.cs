using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migadress4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActived",
                table: "Adresses",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "f141311da6ea44cd9deaa8b48af3266d", "6f184e9dc946a327d378564b9f3d0e945ede8b52ff7aa8b7cf700af45101ebf07e1e2d62d9e60d1d95ba87faf1ca20dd49cbf3aa34d5d690f3bb9e626449ab70", "fca2be7b7916432c90c38f4b6693a7aa3/6/202335235PM" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActived",
                table: "Adresses");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "3f5f1e005be54a43bb82dd0fd73c54e2", "70d65ccdc25919b50698ebf05f2864791cd80c56afebba642994c8a42a3700910eb09f32fce56389e84b966498420a55f6ee032b3ba20e5dd5ab5c6da2de54e1", "9eca5d7fe06c440f943b921ecab5e2d63/6/202331247PM" });
        }
    }
}
