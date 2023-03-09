using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migadress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "2e2c839b25b149d199ea766ce7cd91a5", "829eee1ebbe66810c4c93796b0ea42360586c0abfb1ec8f847e1e9499eea850f146b329852952195744ab1f8dcb2cd941d00766dc9d4a1f734af63f26686d6a6", "87621868c4fb409a980daa6b56d838533/4/202365542PM" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "7daaeb0aecbe4779a2ec7492d309fecc", "346de316ef1d2d05feca7ab6094cd9fcdb27910e4cfffd2e40fbdb238ca0b21914bc38f796b020df4ba03686185ce2ede7d027ca998a5f6d3ff3c426eae5b72d", "95f1782f0a7442da81e259dd90e8f61b3/4/202315705PM" });
        }
    }
}
