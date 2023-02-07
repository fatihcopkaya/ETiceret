using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Categories");

            migrationBuilder.AddColumn<string>(
                name: "SlugUrl",
                table: "Products",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SlugUrl",
                table: "Categories",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "PasswordSalt" },
                values: new object[] { "4506e61404a5473bb90512b9b6baa57e", new byte[] { 107, 35, 68, 188, 139, 160, 218, 68, 123, 85, 165, 115, 25, 197, 116, 207, 170, 196, 97, 97, 51, 134, 243, 101, 172, 236, 102, 187, 0, 152, 133, 37, 138, 126, 27, 229, 220, 137, 134, 98, 74, 87, 177, 231, 31, 149, 207, 148, 45, 120, 175, 56, 127, 217, 177, 101, 41, 239, 99, 249, 246, 104, 123, 12 }, new byte[] { 65, 174, 162, 128, 128, 253, 200, 113, 197, 188, 169, 36, 156, 59, 252, 27, 243, 96, 65, 251, 116, 233, 226, 185, 220, 61, 53, 202, 140, 81, 87, 109, 91, 218, 222, 58, 13, 131, 87, 106, 30, 75, 130, 19, 190, 149, 112, 229, 230, 182, 121, 58, 201, 212, 209, 156, 228, 244, 0, 133, 85, 220, 206, 213, 125, 26, 84, 136, 246, 203, 155, 180, 196, 71, 52, 85, 84, 190, 3, 140, 36, 245, 221, 95, 236, 207, 0, 86, 34, 81, 34, 112, 90, 213, 0, 134, 175, 239, 7, 1, 208, 35, 203, 169, 21, 254, 117, 84, 173, 82, 173, 63, 47, 16, 178, 145, 125, 67, 175, 215, 196, 93, 161, 101, 35, 131, 252, 46 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SlugUrl",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SlugUrl",
                table: "Categories");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "PasswordSalt" },
                values: new object[] { "213ba84bde504d4794c5d0bc94aae674", new byte[] { 123, 251, 134, 244, 128, 36, 86, 156, 30, 121, 10, 154, 128, 247, 191, 229, 209, 30, 154, 147, 3, 244, 23, 144, 60, 111, 82, 10, 62, 99, 207, 215, 159, 41, 90, 28, 26, 140, 118, 90, 74, 179, 202, 129, 96, 197, 35, 215, 3, 43, 13, 217, 132, 255, 190, 158, 65, 6, 24, 202, 200, 209, 131, 147 }, new byte[] { 62, 94, 234, 32, 195, 50, 28, 204, 61, 74, 228, 171, 37, 234, 22, 144, 211, 67, 231, 68, 125, 34, 14, 199, 200, 248, 3, 231, 253, 16, 37, 214, 255, 47, 194, 2, 146, 8, 12, 117, 104, 236, 163, 185, 198, 88, 167, 44, 18, 109, 139, 233, 254, 63, 107, 173, 253, 38, 35, 113, 85, 146, 199, 149, 41, 67, 223, 61, 237, 189, 47, 202, 160, 17, 54, 142, 4, 28, 224, 91, 90, 164, 29, 72, 88, 225, 237, 170, 143, 169, 170, 67, 154, 63, 221, 216, 149, 202, 233, 133, 54, 217, 154, 40, 55, 126, 218, 130, 113, 105, 117, 47, 202, 175, 216, 94, 195, 174, 6, 252, 87, 198, 254, 136, 30, 66, 124, 175 } });
        }
    }
}
