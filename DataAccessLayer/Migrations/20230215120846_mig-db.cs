using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "1958f4561e4c465c96b1a3edf5e7ea25", "461af7639a336a60caf96c9606c4c9e1eff61fa87d28d48123cec8bb2faeb107bb3a6aab1d51d7befd83241b5ba891e74e9246ac6aeb604d44f289e72b542b2f", "8e9bd68446c549dd893b7d40f1b912252/15/202330846PM" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "fae80cd608a647e39711569f3870e04f", "42d9b023f70af6f7700f48655286f7f67843fae884a405e2892592dc283a58e7e86091db43958afa2a1d820594dbe60c54c9b5da0a0131224f73ca030d7e9c0b", "5705c3dc500b41449bb1d9b29ebcbf082/14/202314056AM" });
        }
    }
}
