using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migofferss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActived",
                table: "Offer",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "dc7b01a72cec4ca49a20aaea0afebe73", "49d23cd64506a3df562d2293fa985a97dc3aaba8a981db27d0da822cc885e8ef1c62b29c2a68b201a21d5c03c87b041a6fedc608e93e9d2b5d78e0d1a9054ffb", "71e7a324c69f4c74acc7ee9e5a9ae4d73/9/202330314PM" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActived",
                table: "Offer");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GuId", "PasswordHash", "SecretKey" },
                values: new object[] { "ccee60ccd3f44d56a7cdbd6931eeb737", "78b6eaeb5eff535b57f3b5883160c8a6b715d1f7abf88e02b171590cebbb5dec3e879ade522103eaac565267cd6a13be7b5758ce6b9f5eeaa734a1d1bfcf910e", "237d661d71a64ae6bdaa782af0fc62963/6/202355040PM" });
        }
    }
}
