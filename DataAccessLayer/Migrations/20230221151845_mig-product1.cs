using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migproduct1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contents",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "943fe01e6948479a90905e9962e797d6", "dd7b8f33bf265b9d3f97cf09c0ada60da6022c6fb61e789cb7f3d78ccf9650ccbb65ce6d9408801a3df39599685a1e2619d93fff9d9e0a07b150e14199412e87", "fea372d72f604c7dba0f2d8d5a41d0d02/21/202361845PM" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contents",
                table: "Products",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "d8465a4133224ea2a8ce78353875f84a", "36d24cbebce213371a80d8af18c2f324b34c7492a904a8535d961d0fcfeb16827621bf62a777d56807e19a4e85d1e48308d164bee941a8e6b0d773a0c0c65f75", "f02a61023997444c8499b1e55712d39b2/21/202361833PM" });
        }
    }
}
