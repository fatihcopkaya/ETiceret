using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migprr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "6bbfcb8a259f44bca7d91a25020c193a", "5d54d0106934af85f53dc5b7b51e19a260b7ba4fa53cd1e07afb4cd0b4fa94f6ad100c0f77d11c50f279af332387606cc5d3b0b6ba7abbe6a615cfa01820dba1", "2ab686a0f2ff4ce1b4e146dc8ab954242/25/202341811PM" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "b4bf17b4ec4c4de593f31ecdd19cc521", "081fb8602b202f284bbaf72d15d4813bb059ce04df205dddd88ee42546c45a8bdeb4bd90647c10856e28ab32bead93aa99d1e0131321d2d63807b24001f6e961", "efd21f33f64c4adab8bfc3d9faef96562/25/202341659PM" });
        }
    }
}
