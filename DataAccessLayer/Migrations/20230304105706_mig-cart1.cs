using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migcart1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Total",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "7daaeb0aecbe4779a2ec7492d309fecc", "346de316ef1d2d05feca7ab6094cd9fcdb27910e4cfffd2e40fbdb238ca0b21914bc38f796b020df4ba03686185ce2ede7d027ca998a5f6d3ff3c426eae5b72d", "95f1782f0a7442da81e259dd90e8f61b3/4/202315705PM" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "Carts");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "beb4f6e4f9cc4269a0723307616d03ad", "7e8ce11ef73d76b4ba7aed457baeb75279d4ae6aa2373eb9966ce90d0d914fee6c00ae2ad007d1e46acfc2a8403b1b820258f73f2f71a66468f952b877b77420", "7267f3dd4f49463791b86913021c80393/4/202310831AM" });
        }
    }
}
